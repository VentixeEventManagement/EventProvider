🎉 EventProvider API
A modern, RESTful microservice for event management built with .NET 8.
This API allows you to create, retrieve, update, and delete events—following best practices for scalable microservices in C#.

.NET 8.0 API REST Swagger Documented

📋 Features
Full event management: Create, read, update, and delete events
Participant association: Link participants or resources to specific events
RESTful API: Standard HTTP methods and status codes
Interactive Swagger documentation
Layered architecture: Clear separation of controller, business, and data layers
Entity Framework Core with SQL Server support
Integration testing ready
CORS enabled for all origins
🚀 Getting Started
Prerequisites
.NET 8 SDK
SQL Server (LocalDB is configured by default)
Installation
bash
# 1. Clone the repository
git clone https://github.com/VentixeEventManagement/EventProvider.git
cd EventProvider

# 2. Restore dependencies
dotnet restore

# 3. Apply database migrations
dotnet ef database update --project EventProvider

# 4. Run the application
dotnet run --project EventProvider
