# Ticket 02 - Presupuesto por categorías y asignación

## Historia de usuario
Como usuario, quiero asignar presupuesto por categoría, para distribuir mi dinero de acuerdo con mis metas de gasto y prioridades.

## Requisitos
- crear categorías de gasto
- asignar importe por categoría dentro del mes
- consolidar el total mensual a partir de las categorías
- poder editar la asignación sin afectar el histórico de gastos realizados

## Criterios de aceptación
- cada categoría tiene un nombre y un monto asignado
- el total asignado por categoría suma el presupuesto del mes
- los cambios de asignación se reflejan en la vista del plan mensual

## Dependencias
- ticket 01: plan mensual
- ticket 03: gastos reales
- requerido por ticket 08: app web MVP (consume este endpoint desde la UI)

## Notas técnicas
- entidad recomendada: CategoriaGasto
- quizá requerirá servicio de agregación y validación del total mensual
- considerar futuras categorías por tipo de flujo: fijo, variable, ahorro, recurrente
