# Ticket 09 - App Mobile Android (React Native / Expo)

## Historia de usuario
Como usuario, quiero acceder a mi plan mensual y registrar gastos desde una app Android, para consultar y actualizar mi presupuesto desde el celular.

## Requisitos
- implementar `apps/mobile` (React Native + Expo + TypeScript)
- reutilizar `packages/shared` y `packages/api-client` del monorepo de UI
- construir pantallas mínimas: consulta de plan mensual, registro de gasto, variación presupuesto vs. real
- validar ejecución en Android vía Expo Go o build de desarrollo

## Criterios de aceptación
- la app corre en un emulador o dispositivo Android
- el usuario puede consultar su plan mensual desde la app
- el usuario puede registrar un gasto real desde la app
- la lógica de negocio compartida (`packages/shared`) no se duplica respecto a la app web

## Dependencias
- ticket 07: alta del repositorio de UI
- ticket 08: app web MVP (para reutilizar `packages/shared` y `packages/api-client` ya probados)

## Notas técnicas
- los componentes visuales de React Native no son los mismos que los de web; solo se comparte lógica/hooks/tipos vía `packages/shared`
- dejar preparado el build de Android (EAS Build) para el ticket 11 de CI/CD
