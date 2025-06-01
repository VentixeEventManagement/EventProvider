using EventProvider.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using EventProvider.Business.Interfaces;
using EventProvider.Business.Services;
using EventProvider.Data.Interfaces;
using EventProvider.Data.Repositories;
using Swashbuckle.AspNetCore.Filters;
using EventProvider.SwaggerExamples;

/// <remarks>
/// This code was formatted and refined using AI assistance.
/// </remarks>

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamplesFromAssemblyOf<EventExample>();

// AI-generated code: Swagger XML comments configuration
var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "EventProvider API",
        Version = "v1",
        Description = @"EventProvider Microservice

This microservice provides a RESTful API for event management, allowing clients to create, 
read, update, and delete event information. It follows a layered architecture pattern with
clear separation of concerns:

Architecture Overview:
- Controllers: Handle HTTP requests and responses (API endpoints)
- Business Layer: Contains business logic, services, and domain models
- Data Access Layer: Manages data persistence through repositories and entities

Key Components:
- EventController: Exposes REST endpoints for event CRUD operations
- EventService: Implements business logic for event management
- EventRepository: Handles data access operations for events
- Event: Domain model representing an event in the system

The API is documented using Swagger/OpenAPI, accessible at the root URL.
Data is persisted using Entity Framework Core with SQL Server.

For more details on available endpoints and data models, refer to the Swagger UI."
    });

    options.IncludeXmlComments(xmlPath);
    options.EnableAnnotations();
});

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddMemoryCache();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "EventProvider API v1");
});

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();