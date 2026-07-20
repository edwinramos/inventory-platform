# 🚀 Inventory Platform

> **A production-oriented Inventory Management API built with .NET 10 using Clean Architecture, CQRS, and modern backend development practices.**

Este proyecto demuestra cómo construir un sistema de gestión de inventario **escalable, mantenible y listo para producción**, aplicando patrones de arquitectura empresarial en lugar de desarrollar una simple aplicación CRUD.

---

# ✨ Características

## 🔐 Autenticación
- ✅ JWT Authentication
- ✅ ASP.NET Identity
- ✅ Secure Password Hashing
- ✅ Role-Based Authorization (Ready)
- ✅ Protected Endpoints

---

## 📦 Gestión de Productos
- ✅ Crear productos
- ✅ Obtener producto por ID
- ✅ Listado paginado
- ✅ DTO Projections para consultas optimizadas

---

## 📊 Gestión de Inventario
- ✅ Agregar inventario
- ✅ Remover inventario
- ✅ Consulta de stock actual
- ✅ Historial de movimientos de inventario

---

# 🏗️ Arquitectura

Este proyecto implementa patrones utilizados en aplicaciones empresariales:

- 🧱 Clean Architecture
- 📨 CQRS con MediatR
- 🗄️ Repository Pattern
- 💉 Dependency Injection
- ⚡ Minimal APIs
- 🚨 Global Exception Handling

---

# 🛠️ Stack Tecnológico

| Categoría | Tecnología |
|-----------|------------|
| 💻 Backend | .NET 10 |
| 🏗️ Arquitectura | Clean Architecture |
| 🌐 API | Minimal APIs |
| 🔐 Autenticación | JWT + ASP.NET Identity |
| 🗄️ Base de Datos | PostgreSQL |
| 📚 ORM | Entity Framework Core |
| 📨 Messaging | MediatR |
| 🐳 Contenedores | Docker + Docker Compose |
| 📖 Documentación | Swagger |
| ❤️ Health Monitoring | ASP.NET Health Checks |

---

# 📁 Estructura del Proyecto

```text
src/
├── InventoryPlatform.Api
├── InventoryPlatform.Application
├── InventoryPlatform.Domain
└── InventoryPlatform.Infrastructure
```

---

# ▶️ Ejecutar Localmente

## Levantar la aplicación

```bash
dotnet ef database update --project src/InventoryPlatform.Infrastructure --startup-project src/InventoryPlatform.Api

docker compose up --build
```

---

## 📖 Swagger

```
http://localhost:5075/swagger
```

---

## ❤️ Health Check

```
http://localhost:5075/health
```

---

# ✅ Implementado Actualmente

- ✔️ Clean Architecture
- ✔️ CQRS
- ✔️ Repository Pattern
- ✔️ Dependency Injection
- ✔️ DTO Projections
- ✔️ JWT Authentication
- ✔️ Health Checks
- ✔️ Dockerized Development Environment

---

# 🗺️ Roadmap

Próximas funcionalidades:

- 🚀 Redis Caching
- 🔄 CI/CD Pipeline
- 📈 OpenTelemetry
- ⚙️ Background Jobs
- 📢 Domain Events
- 📬 Outbox Pattern
- 🧪 Integration Tests
- 📊 Metrics & Monitoring

---

# 🎯 Objetivo

Este proyecto forma parte de mi camino para convertirme en **Senior Backend Engineer**, enfocándome en:

- Arquitectura de software
- Escalabilidad
- Clean Code
- Buenas prácticas
- Desarrollo orientado a producción
- Sistemas mantenibles y extensibles

---

# ⭐ Si te gusta este proyecto...

¡No olvides darle una **⭐ Star** al repositorio!

También puedes abrir un **Issue** o enviar un **Pull Request** si tienes sugerencias o mejoras.

---

## 👨‍💻 Desarrollado con ❤️ usando .NET 10
