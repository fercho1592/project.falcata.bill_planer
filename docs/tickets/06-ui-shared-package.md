# Ticket 06 - Paquete UI compartido (Falcata.UI.Common)

## Historia de usuario
Como equipo de desarrollo, quiero un paquete compartido de UI reutilizable entre los distintos productos de Falcata, para no duplicar tema, cliente HTTP y autenticación en cada repositorio de frontend.

## Requisitos
- crear el repositorio `project.falcata.ui_common`
- definir tema/design system base (componentes visuales genéricos)
- implementar cliente HTTP base con manejo de reintentos y errores
- implementar helpers de autenticación OIDC reutilizables para web y mobile
- publicar el paquete versionado a un registro privado (GitHub Packages npm)

## Criterios de aceptación
- el paquete se publica con una versión inicial consumible desde otro repositorio
- el tema y los componentes genéricos están documentados con ejemplos de uso
- el cliente HTTP soporta interceptores para autenticación y reintentos configurables

## Dependencias
- ninguna (es la base para los demás tickets de UI)

## Notas técnicas
- alcance inicial mínimo: solo tema + cliente HTTP + helpers de auth; ampliar solo cuando exista duplicación real confirmada entre las UIs de BillPlanner y PayRestaurant
- pensar en compatibilidad con React (web) y React Native/Expo (mobile)
