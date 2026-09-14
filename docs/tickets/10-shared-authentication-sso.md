# Ticket 10 - Autenticación compartida (SSO) entre UIs

## Historia de usuario
Como usuario, quiero iniciar sesión una sola vez y acceder tanto a BillPlanner como a Pay Restaurant, para no manejar credenciales separadas por producto.

## Requisitos
- definir un Identity Provider compartido (recomendado: proveedor gestionado tipo Auth0 o Azure AD B2C)
- integrar login OIDC en `apps/web` (ej. `oidc-client-ts`) y `apps/mobile` (ej. `react-native-app-auth`)
- asegurar que BillPlanner.API valide JWT emitidos por el mismo issuer usado por Pay Restaurant.API
- centralizar la lógica de autenticación reutilizable en `Falcata.UI.Common`

## Criterios de aceptación
- un usuario autenticado en la app web de BillPlanner puede autenticarse en Pay Restaurant sin volver a ingresar credenciales (SSO)
- las llamadas a BillPlanner.API incluyen el token y son rechazadas si no son válidas
- cada usuario solo ve su propia información financiera (aislamiento por usuario)

## Dependencias
- ticket 07: alta del repositorio de UI
- ticket 06: paquete UI compartido (Falcata.UI.Common)
- ticket 05: seguridad y acceso personal al presupuesto (BillPlanner.API debe implementar validación de autenticación/autorización)

## Notas técnicas
- requiere coordinación con el repositorio de Pay Restaurant para compartir el mismo issuer/Identity Provider
- evaluar si se requiere un repositorio adicional de Identity Provider solo si se decide no usar un proveedor gestionado
