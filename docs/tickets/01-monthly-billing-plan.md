# Ticket 01 - Plan mensual de gastos

## Historia de usuario
Como usuario, quiero crear y mantener un plan mensual de gastos, para distribuir mi presupuesto de forma clara y controlar lo disponible en cada periodo.

## Requisitos
- definir un plan mensual con fecha de inicio y fin
- registrar presupuesto total del mes
- asociar el plan a una persona o cuenta de usuario
- consultar el total asignado y el saldo restante

## Criterios de aceptación
- el usuario puede crear un plan mensual
- el plan guarda fecha inicio y fin
- se puede consultar el presupuesto total y lo disponible
- si se modifica el plan, el sistema refleja el cambio en reportes y cálculos

## Dependencias
- ticket 02: presupuestos por categoría
- ticket 03: registro de gastos reales

## Notas técnicas
- entidad recomendada: PlanMensual
- capa de dominio: validar fechas y totales
- capa de aplicación: casos de uso de creación y consulta
