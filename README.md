EventProvider
EventProvider is a microservice that provides a RESTful API for event management. It allows clients to create, read, update, and delete event information. The project is built with .NET 8 and C# 12, following a layered architecture for clear separation of concerns.
Features
•	CRUD operations for event management via RESTful API
•	Layered architecture:
•	Controllers: Handle HTTP requests and responses (API endpoints)
•	Business Layer: Contains business logic, services, and domain models
•	Data Access Layer: Manages data persistence through repositories and entities
•	API documentation with Swagger/OpenAPI
•	Entity Framework Core with SQL Server (or in-memory database for testing)
•	CORS support for cross-origin requests
•	Memory caching for improved performance
Key Components
•	EventController: Exposes REST endpoints for event CRUD operations
•	EventService: Implements business logic for event management
•	EventRepository: Handles data access operations for events
•	Event: Domain model representing an event in the system
Getting Started
Prerequisites
•	.NET 8 SDK
•	SQL Server (unless using in-memory database for testing)
Setup
1.	Clone the repository:
•	Use your preferred method to clone this repository to your local machine.
2.	Configure the database:
•	Update the connection string in appsettings.json to point to your SQL Server instance.
3.	Apply database migrations:
•	Use the .NET CLI or Visual Studio to apply Entity Framework Core migrations and create the database schema.
4.	Run the application:
•	Start the project using Visual Studio or the .NET CLI.
5.	Access the API documentation:
•	Open your browser and navigate to the root URL (typically https://localhost:5001 or similar) to view the Swagger UI and explore the API endpoints.
Testing
•	The project includes integration and unit tests.
•	Use your preferred test runner or the .NET CLI to execute tests in the EventProvider.Tests project.
Project Structure
•	Controllers: API endpoint definitions
•	Business: Services, interfaces, models, and factories for business logic
•	Data: Database context, repositories, entities, and interfaces
•	SwaggerExamples: Example data for Swagger documentation
•	Migrations: Entity Framework Core migration files
API Documentation
•	The API is fully documented using Swagger/OpenAPI.
•	XML comments are included for enhanced documentation.
•	Example requests and responses are provided in the Swagger UI.
Configuration
•	appsettings.json: Main configuration file for connection strings and other settings
•	appsettings.Development.json: Development-specific overrides
•	launchSettings.json: Launch profiles for local development
Contributing
Contributions are welcome! Please open issues or submit pull requests for any improvements or bug fixes.
License
This project is licensed under the MIT License.
---
EventProvider makes event management simple, robust, and scalable. For more details on available endpoints and data models, refer to the Swagger UI after running the application.
