# Notas de dependencia y arquitectura

## 1. Dependencias funcionales

Los módulos del sistema están relacionados de la siguiente forma:

- Presupuesto mensual depende del registro de categorías y cuentas.
- Gasto real depende de la categoría, cuenta y período del plan mensual.
- Pagos planeados dependen de presupuesto mensual, categoría y posible historial de moneda.
- Análisis por tag y ubicación depende del registro de cada gasto.

## 2. Dependencias de servicios

### 2.1 API de Bill Planner
La API principal debe exponer endpoints para:

- crear/consultar planes mensuales
- registrar gastos reales
- consultar saldos y proyecciones
- registrar pagos previstos
- obtener estructuras de analítica por tag, cuenta y ubicación

### 2.2 Capas de aplicación y dominio
La solución actual contempla arquitectura basada en Clean Architecture y CQRS, por lo que se recomienda:

- mantener validaciones y reglas de negocio en el dominio
- encapsular casos de uso en la capa de aplicación
- usar la capa de infraestructura solo para persistencia y servicios externos

### 2.3 Servicio de conversión de moneda
Para soporte futuro de monedas, se requerirá un servicio de conversión o un adaptador a una fuente externa de tasas de cambio. Este servicio debe:

- aceptar una moneda origen, moneda destino y fecha
- devolver el factor de conversión
- apoyar una tasa histórica o vigente según el caso
- permitir trazabilidad del valor estimado

### 2.4 Servicio de calendario / recurrencia
Para pagos recurrentes y calendario financiero, se recomienda crear o extender un módulo de programación para:

- generar instancias recurrentes por frecuencia
- calcular fechas de pago
- exponer eventos o recordatorios

## 3. Recomendación de diseño

Se sugiere separar los siguientes dominios:

- Budgeting
- ExpenseTracking
- PlannedPayments
- RecurrenceManagement
- CurrencyConversion
- ReportingAndAnalytics

Esto permitirá crecer sin acoplar la lógica de monedas o calendario a los gastos reales.

## 4. Riesgos de diseño a evitar

- mezclar pagos ejecutados y pagos planeados en una sola entidad sin distinguir estado
- asumir que todas las transacciones usan la misma moneda
- permitir editar gastos ya ejecutados sin dejar trazabilidad
- hacer el calendario dependiente del módulo de gastos reales sin una capa independiente

## 5. Tareas futuras sugeridas

- definir catálogo de monedas
- definir servicio de tasas
- crear módulo de frecuencia de pagos
- crear vista de calendario financiero
- definir reportes por tag/cuanta/ubicación
