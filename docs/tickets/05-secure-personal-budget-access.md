# Ticket 05 - Seguridad y acceso personal al presupuesto

## Historia de usuario
Como usuario, quiero que mis datos financieros estén protegidos y accesibles solo para mi cuenta, para mantener la confidencialidad de mi presupuesto personal.

## Requisitos
- autenticación de usuario para acceder a planes y gastos
- aislamiento de datos por usuario
- autorización en endpoints de presupuesto y gastos
- protección de información sensible

## Criterios de aceptación
- cada usuario ve únicamente su información financiera
- un usuario no puede acceder al presupuesto de otro usuario
- los endpoints de lectura y escritura validan permisos

## Dependencias
- tickets 01 a 04
- requerido por ticket 10: autenticación compartida (SSO) entre UIs

## Notas técnicas
- requiere integración con el sistema de autenticación/autorización de la solución
- el modelo de dominio debe incluir propietario o usuario relacionado
- recomendable aplicar validación por tenant o owner en los repositorios y queries
