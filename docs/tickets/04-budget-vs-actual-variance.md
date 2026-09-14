# Ticket 04 - Variación entre presupuesto y gasto real

## Historia de usuario
Como usuario, quiero comparar mi presupuesto mensual contra lo gastado realmente, para saber si voy adelante o atrasado en el periodo.

## Requisitos
- calcular el total gastado del periodo
- calcular saldo disponible
- comparar gasto real con presupuesto mensual
- mostrar estado de riesgo o alerta si se excede el presupuesto
- calcular proyección del gasto restante del mes

## Criterios de aceptación
- el sistema calcula el total gastado del periodo correctamente
- el saldo disponible se actualiza en tiempo real
- la UI o respuesta API incluye un indicador de desviación
- se muestran mensajes claros cuando el gasto excede el presupuesto

## Dependencias
- ticket 01: plan mensual
- ticket 03: gastos reales

## Notas técnicas
- probablemente requerirá consulta agregada y cálculo de KPI financiero
- puede resolverse con query handlers para dashboard y resumen mensual
- se recomienda separar lógica de cálculo del dominio para reportes
