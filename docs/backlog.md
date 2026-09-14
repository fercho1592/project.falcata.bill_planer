# Backlog de requisitos del planificador financiero personal

## 1. Propósito

Este documento consolida las historias de usuario y requisitos funcionales derivados del análisis del archivo de planificación de gastos. Sirve como base para la definición de tickets, priorización y desarrollo incremental.

## 2. Requisitos funcionales principales

- registrar gastos reales del mes
- comparar gasto real vs presupuesto mensual
- organizar y asignar categorías a los gastos
- planear presupuesto por semana
- registrar pagos previstos con fecha estimada
- diferenciar entre gasto ejecutado y gasto planeado
- agrupar gastos por tag, cuenta y ubicación
- soportar monedas o unidades de valor distintas
- preparar la base para pagos recurrentes y calendario financiero

## 3. Epicas sugeridas

### Epic 1: Gestión del presupuesto mensual
- creación y edición de un plan mensual
- asignación de presupuesto por categoría
- cálculo de saldo disponible

### Epic 2: Registro de gastos
- registro de movimientos reales
- validación de monto y fecha
- integridad histórica de gastos ejecutados

### Epic 3: Planeación y proyección
- presupuesto semanal
- comparación de avance real vs plan
- cálculo del gasto restante proyectado

### Epic 4: Pagos previstos y recurrentes
- registro de pagos futuros
- manejo de frecuencia
- visualización por calendario y por fecha

### Epic 5: Análisis financiero
- agrupación por tag, cuenta y ubicación
- reportes y filtros
- análisis multi-moneda y conversión dynamic

## 4. Observaciones clave

- Los pagos realizados deben quedar como información histórica y no modificable.
- Los pagos planeados deben poder actualizarse con estimación.
- La moneda y la frecuencia deben tratarse como variables del dominio, incluso si su implementación se realiza en fases posteriores.

## 5. Definición de prioridad sugerida

### Alta prioridad
- presupuesto mensual
- registro de gastos reales
- comparación gasto vs presupuesto
- pagos planeados básicos

### Media prioridad
- planeación semanal
- análisis por tag, cuenta y ubicación
- filtros y reportes

### Baja prioridad / futuro
- soporte de múltiples monedas
- pagos recurrentes con frecuencia
- calendario financiero

## 6. Nota técnica

Se recomienda diseñar primero los módulos base y dejar extensiones futuras mediante separación clara de dominios: presupuesto, gastos, pagos previstos, moneda y recurrencia.
