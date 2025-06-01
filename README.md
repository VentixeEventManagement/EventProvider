# 🎟️ EventProvider API

A modern, RESTful microservice for Event management built with **.NET 8**.  
This API enables you to create, retrieve, update, and delete events, following best practices for microservice architecture.

![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512BD4)
![API REST](https://img.shields.io/badge/API-REST-8A2BE2)
![Swagger Documented](https://img.shields.io/badge/Swagger-Documented-85EA2D)

---

## 📋 Features

- **Full Event management:** Create, read, update, and delete operations
- **RESTful API:** Standard HTTP methods and status codes
- **Interactive Swagger documentation**
- **Layered architecture:** Clear separation of controller, business, and data layers
- **Entity Framework Core with SQL Server support**
- **Comprehensive integration testing**
- **CORS enabled** for all origins

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (**LocalDB** is configured by default)

### Installation

```bash
# 1. Clone the repository
git clone [https://github.com/your-username/ticket-provider.git](https://github.com/VentixeEventManagement/EventProvider)
cd ticket-provider

# 2. Restore dependencies
dotnet restore

# 3. Apply database migrations
