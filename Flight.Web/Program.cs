using Flight.Application.Common;
using Flight.Infrastructure;
using MediatR.Pipeline;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Flight.Application.Subscriptions;
using System.Reflection;
using Flight.Application.Subscriptions.Dto;
using Flight.Application.Interfaces.Repositories;
using Flight.Infrastructure.Repositories;
using Flight.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<FlightDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(SubscriptionMapper).GetTypeInfo().Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SubscriptionCommand).GetTypeInfo().Assembly));

builder.Services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(CommitCommandPostProcessor<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IRouteRepository, RouteRepository>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Documentation",
        Description = "ASP.NET Core Web API"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty; // Swagger UI را در ریشه برنامه نمایش میدهد
});

app.UseAuthorization();

app.MapControllers();

app.Run();