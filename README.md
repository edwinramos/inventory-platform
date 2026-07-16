Inventory Platform

A production-oriented Inventory Management API built with .NET 10, following Clean Architecture, CQRS, and modern backend development practices.

The goal of this project is to demonstrate how a scalable inventory management system can be structured using enterprise-grade patterns rather than building a simple CRUD application.

Features
Authentication
JWT Authentication
ASP.NET Identity
Secure password hashing
Role-ready authorization
Protected endpoints
Product Management
Create products
Get product by ID
Paginated product listing
DTO projections for optimized queries
Inventory Management
Add stock
Remove stock
Current stock lookup
Inventory movement history
Architecture
Clean Architecture
CQRS with MediatR
Repository Pattern
Dependency Injection
Minimal APIs
Global Exception Handling
Infrastructure
PostgreSQL
Entity Framework Core
Docker
Docker Compose
Health Checks
Tech Stack
Category	Technology
Backend	.NET 10
Architecture	Clean Architecture
API	Minimal APIs
Authentication	JWT + ASP.NET Identity
Database	PostgreSQL
ORM	Entity Framework Core
Messaging	MediatR
Containerization	Docker
Documentation	Swagger
Running locally
docker compose up --build

Swagger

http://localhost:5075/swagger

Health Check

http://localhost:5075/health
Project Structure
src/
 ├── InventoryPlatform.Api
 ├── InventoryPlatform.Application
 ├── InventoryPlatform.Domain
 └── InventoryPlatform.Infrastructure
Current Architecture
Clean Architecture
CQRS
Repository Pattern
Dependency Injection
DTO Projections
JWT Authentication
Health Checks
Dockerized Development Environment
Roadmap

Future improvements include:

Redis Caching
CI/CD Pipeline
OpenTelemetry
Background Jobs
Domain Events
Outbox Pattern
Purpose

This project was built as part of my journey toward becoming a Senior Backend Engineer, focusing on software architecture, scalability, and production-ready development practices.
