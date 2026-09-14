# Ticket 07 - Alta del repositorio de UI (Bill Planner)

## Historia de usuario
Como equipo de desarrollo, quiero dar de alta un repositorio dedicado a la interfaz de usuario de BillPlanner, para separar el frontend del backend siguiendo el patrón multi-repo del ecosistema Falcata.

## Requisitos
- crear el repositorio `project.falcata.bill_planer_ui`
- inicializar un monorepo con workspaces (pnpm o npm): `apps/web`, `apps/mobile`, `packages/api-client`, `packages/shared`
- agregar `Falcata.UI.Common` como dependencia del workspace
- configurar linting/formatting base (ESLint, Prettier, TypeScript en modo estricto)
- documentar README y AGENTS.md siguiendo el estilo del repositorio backend actual

## Criterios de aceptación
- el repositorio existe y es accesible en la organización
- `pnpm install` (o `npm install`) resuelve el workspace sin errores
- el README documenta cómo levantar la app web localmente contra la API de BillPlanner

## Dependencias
- ticket 06: paquete UI compartido (Falcata.UI.Common)

## Notas técnicas
- este ticket es solo de scaffolding; no incluye pantallas ni lógica de negocio
- dejar `apps/mobile` y `packages/api-client` como paquetes vacíos listos para los tickets 08 y 09
