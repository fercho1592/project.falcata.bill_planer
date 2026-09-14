# Análisis financiero del plan de gastos personal

## 1. Objetivo del análisis

Este documento recoge el análisis funcional del archivo de planificación de gastos y sirve como base de referencia para el desarrollo de la aplicación de gestión financiera personal.

El archivo contiene varios bloques funcionales:

- registro real de gastos
- resumen del estado mensual
- planeación por semanas
- pagos planeados con estimaciones
- agrupaciones por etiquetas, cuentas y ubicaciones

## 2. Alcance observado en el archivo

### 2.1 Hojas de trabajo foco
Se enfocó el análisis en los siguientes periodos:

- Marzo 2025 - Gastos
- Abril 2025 - Gastos
- Mayo 2025 - Gastos
- Junio 2025 - Gastos

Estas hojas comparten una estructura financiera similar y permiten validar la lógica del producto para todos los meses del ciclo de presupuesto.

### 2.2 Registro de gastos reales
Las columnas A:F se usan como bitácora de gastos.

El registro real de gasto debe permitir:

- fecha del movimiento
- descripción del concepto
- monto
- categoría
- cuenta asociada
- tag o etiqueta
- ubicación
- notes o comentarios opcionales

Este bloque representa el historial de movimientos ejecutados y debe ser inmodificable una vez consolidado como gasto realizado.

### 2.3 Resumen general del mes
La tabla H1:J8 contiene el estado general del período.

Debe reflejar:

- monto total planeado para el mes
- monto ejecutado real
- monto disponible
- rango de fechas del período
- tiempo restante
- gasto estimado o proyectado restante

Reglas esperadas:

- presupuesto total = sumatoria del monto planificado en el período
- gasto real = suma de egresos registrados y confirmados
- saldo disponible = presupuesto - gasto real
- gasto proyectado restante = estimación de lo que faltará gastar antes de terminar el periodo
- si el gasto real supera el presupuestado, el sistema debe mostrar un estado de riesgo o over budget

### 2.4 Planeación semanal simplificada
La tabla H11:J18 define una planificación resumida por semanas.

Debe permitir:

- asignar presupuesto por semana
- comparar plan semanal vs gastos reales
- detectar adelantos o retrasos por semana
- resumir el comportamiento del mes de forma granular

El total de las semanas debe coincidir con el presupuesto mensual.

### 2.5 Pagos planeados
La tabla L1:N12 contiene pagos previstos con estimación y fecha esperada.

Debe permitir:

- definir pagos pendientes o futuros
- registrar monto estimado
- registrar fecha esperada
- clasificarlos por categoría o cuenta
- indicar estado: pendiente, ejecutado, cancelado, etc.

Estos pagos forman parte del flujo financiero futuro y deben distinguirse claramente de los gastos ejecutados.

### 2.6 Agrupación por tag, cuenta y ubicación
Las columnas O:V agrupan información de gastos por:

- etiquetas / tags
- cuentas
- ubicaciones
- posiblemente categorías adicionales

Esto permite generar un análisis transversal del comportamiento del gasto y ayuda a la toma de decisiones.

## 3. Reglas de negocio principales

1. El sistema debe manejar el flujo financiero real y planeado por separado.
2. El presupuesto mensual es la base de comparación para gastos reales.
3. Los gastos realizados deben conservar su integridad histórica.
4. Los pagos planeados pueden actualizarse antes de ejecutarse.
5. Los gastos deben analizarse por categoría, cuenta, etiqueta y ubicación.
6. La estimación de gastos debe distinguir entre presupuesto, consumo real y proyección futura.

## 4. Consideraciones para desarrollo futuro

### 4.1 Monedas y unidades de valor
Se identificó una necesidad clara para soportar pagos en monedas o unidades distintas a la moneda local.

Ejemplos:

- UDI
- UMA
- dólares
- otras unidades futuras

Esto debe considerarse como requisito de diseño para futuro desarrollo, con la siguiente regla:

- los pagos realizados quedan inmodificables
- los pagos planeados pueden consultarse dinámicamente con su moneda y valor estimado
- la conversión debe poder resolverse usando tasas o factores vigentes por fecha

Se recomienda modelar la moneda como entidad o catálogo, con:

- identificador
- nombre
- símbolo
- tipo de unidad
- tasa de conversión relativa a la moneda base
- fecha de referencia

### 4.2 Pagos recurrentes y frecuencia
Hay pagos que no ocurren una vez, sino de forma periódica, por ejemplo:

- seguros
- mantenimiento del vehículo
- servicios anuales
- cuotas repetitivas

Se recomienda considerar una funcionalidad de frecuencia para pagos recurrentes, con ejemplos como:

- único
- mensual
- bimestral
- trimestral
- semestral
- anual
- personalizada

Este requisito debe ser contemplado como base para un futuro módulo de calendario de pagos.

## 5. Modelo de dominio sugerido

La solución probablemente requiere entidades como:

- PlanMensual
- PresupuestoMensual
- CategoriaGasto
- Cuenta
- Etiqueta
- Ubicacion
- GastoReal
- PagoPlaneado
- FrecuenciaPago
- Moneda
- ConversionMoneda

## 6. Historias de usuario derivadas

- registrar gastos reales
- ver el estado del presupuesto mensual
- planear gastos por semana
- registrar pagos previstos
- analizar gastos por etiqueta, cuenta y ubicación
- soportar monedas distintas para estimación
- manejar pagos recurrentes
- visualizar fecha de vencimientos y flujo futuro

## 7. Conclusión

La estructura del archivo refleja un sistema financiero personal orientado a la comparación entre plan de gastos, gastos reales y flujo futuro. El producto debe enfocarse en tres dimensiones clave:

- control del presupuesto
- visibilidad del gasto real
- proyección del flujo futuro

Las observaciones de moneda y frecuencia son relevantes para evitar un diseño que solo sirva para una moneda única o un flujo totalmente manual.
