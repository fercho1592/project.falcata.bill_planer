# Ticket 03 - Registro y categorización de gastos

## Historia de usuario
Como usuario, quiero registrar mis gastos reales con fecha, monto y categoría, para medir el consumo real frente a mi plan.

## Requisitos
- registrar gastos con descripción, monto y fecha
- asignar categoría, cuenta, etiqueta y ubicación
- guardar el gasto en el periodo correspondiente
- mantener historial de movimientos ejecutados

## Criterios de aceptación
- el sistema guarda el gasto real en la base de datos
- el gasto se suma al total del mes correspondiente
- los gastos registrados no pueden ser modificados si ya fueron consolidados como ejecutados
- el registro puede consultarse por fecha, categoría o cuenta

## Dependencias
- ticket 01: plan mensual
- ticket 02: categorías
- requerido por ticket 08: app web MVP (consume este endpoint desde la UI)

## Notas técnicas
- entidad recomendada: GastoReal
- necesaria validación de monto positivo
- consideraciones: historial inmodificable y trazabilidad de movimientos
