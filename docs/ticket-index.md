# Índice de tickets del backlog

## 1. Propósito

Este índice organiza el backlog en historias de usuario por archivo, permitiendo una lectura rápida de la evolución del producto.

## 2. Tickets

- [01 - Plan mensual de gastos](tickets/01-monthly-billing-plan.md)
- [02 - Presupuesto por categorías y asignación](tickets/02-budget-categories-and-allocation.md)
- [03 - Registro y categorización de gastos](tickets/03-record-and-categorize-expenses.md)
- [04 - Variación entre presupuesto y gasto real](tickets/04-budget-vs-actual-variance.md)
- [05 - Seguridad y acceso personal al presupuesto](tickets/05-secure-personal-budget-access.md)
- [06 - Paquete UI compartido (Falcata.UI.Common)](tickets/06-ui-shared-package.md)
- [07 - Alta del repositorio de UI (Bill Planner)](tickets/07-ui-repository-setup.md)
- [08 - App Web MVP (React)](tickets/08-web-app-mvp.md)
- [09 - App Mobile Android (React Native / Expo)](tickets/09-mobile-app-android.md)
- [10 - Autenticación compartida (SSO) entre UIs](tickets/10-shared-authentication-sso.md)
- [11 - CI/CD para el repositorio de UI](tickets/11-ui-cicd.md)

## 3. Tickets futuros sugeridos

- soporte de múltiples monedas y unidades de valor
- pagos recurrentes con frecuencia
- calendario financiero de vencimientos
- análisis avanzado por etiquetas, ubicaciones y cuentas
- integración con servicios externos de tipo de cambio

## 4. Dependencias entre tickets

- El ticket 01 debe preceder a 02 y 03.
- El ticket 03 es base para 04.
- El ticket 05 es transversal y puede trabajarse en paralelo a los demás.
- Los tickets de moneda y recurrencia deben desarrollarse después de la base de presupuesto y gastos.
- El ticket 06 (paquete UI compartido) no depende de ningún otro y es la base de los tickets 07 a 11.
- El ticket 07 (alta del repositorio de UI) depende del ticket 06 y precede a los tickets 08 a 11.
- El ticket 08 (app web MVP) depende del ticket 07 y de los tickets 01, 02, 03 y 04 (endpoints de backend que la UI consume).
- El ticket 09 (app mobile Android) depende de los tickets 07 y 08.
- El ticket 10 (SSO entre UIs) depende de los tickets 06, 07 y 05 (seguridad en el backend).
- El ticket 11 (CI/CD de UI) depende de los tickets 07, 08 y 09.
