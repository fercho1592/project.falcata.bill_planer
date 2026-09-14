# Ticket 11 - CI/CD para el repositorio de UI

## Historia de usuario
Como equipo de desarrollo, quiero pipelines de integración continua para el repositorio de UI, para validar builds, pruebas y artefactos de forma automática en cada cambio.

## Requisitos
- configurar GitHub Actions para lint, build y test de `apps/web` (Vitest + React Testing Library)
- configurar GitHub Actions para lint, build y test de `apps/mobile` (Jest + RN Testing Library)
- configurar build de artefacto Android vía EAS Build para `apps/mobile`
- fallar el pipeline si `packages/api-client` queda desactualizado respecto al OpenAPI del backend

## Criterios de aceptación
- cada pull request ejecuta lint, build y pruebas automáticamente
- se genera un artefacto de Android instalable desde el pipeline
- el pipeline detecta si el cliente API generado no coincide con el contrato actual del backend

## Dependencias
- ticket 07: alta del repositorio de UI
- ticket 08: app web MVP
- ticket 09: app mobile Android

## Notas técnicas
- reutilizar convenciones de pipeline si ya existen en los repositorios backend del ecosistema Falcata
- considerar cache de dependencias del workspace para acelerar los builds
