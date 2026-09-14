# Ticket 08 - App Web MVP (React)

## Historia de usuario
Como usuario, quiero una aplicación web donde pueda gestionar mi plan mensual, categorías, gastos y variación presupuestal, para interactuar con BillPlanner sin usar la API directamente.

## Requisitos
- implementar `apps/web` (React + TypeScript + Vite)
- generar `packages/api-client` desde el OpenAPI/Swagger de BillPlanner.API (orval u openapi-typescript)
- construir pantallas para: plan mensual, categorías y asignación, registro de gastos, variación presupuesto vs. real
- integrar manejo de datos remotos con React Query

## Criterios de aceptación
- el usuario puede crear/consultar un plan mensual desde la UI
- el usuario puede asignar presupuesto por categoría desde la UI
- el usuario puede registrar un gasto real desde la UI
- la UI muestra la comparación de gasto real vs. presupuesto con indicador de desviación

## Dependencias
- ticket 07: alta del repositorio de UI
- ticket 01: plan mensual de gastos
- ticket 02: presupuesto por categorías y asignación
- ticket 03: registro y categorización de gastos
- ticket 04: variación entre presupuesto y gasto real

## Notas técnicas
- priorizar componentes simples y manuales al inicio para practicar React antes de introducir generación automática de cliente API
- las pantallas deben consumir `packages/api-client` y no llamar a la API directamente con fetch/axios sueltos
