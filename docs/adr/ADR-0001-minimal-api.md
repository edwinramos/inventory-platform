# ADR-0001: Adopt Minimal APIs with Vertical Slice Architecture

## Status

Accepted

## Context

The project requires an API architecture that is scalable, testable, and minimizes unnecessary boilerplate. Traditional MVC controllers often become large and require frequent modifications as the application grows.

## Decision

The project will use ASP.NET Core Minimal APIs for defining HTTP endpoints. Each endpoint will belong to a Vertical Slice feature and delegate business logic to MediatR handlers.

## Consequences

### Advantages

- Reduced boilerplate.
- Better feature cohesion.
- Cleaner Program.cs.
- Easier endpoint discovery.
- Better alignment with CQRS.
- Improved maintainability.

### Trade-offs

- Less familiar to developers accustomed to MVC controllers.
- Some enterprise teams still prefer controllers for consistency.

## Alternatives Considered

- MVC Controllers
- FastEndpoints
- Carter

## Decision Date

2026-07-04