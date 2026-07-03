using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.PostgreSql;
using Mapster;
using Himgiri.Core.Interfaces.Repositories;
using Himgiri.Core.Interfaces.Services;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Data.Transactions;
using Himgiri.Infrastructure.Services;
using Himgiri.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Himgiri.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<HimgiriDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration config)
    {
        var key = config["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key missing in config.");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };

                // Log exactly why a token fails to the console
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"[AUTH FAILED] {context.Exception.Message}");
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));
            options.AddPolicy("InventoryOrAdmin", policy => policy.RequireRole("SuperAdmin", "InventoryManager"));
            options.AddPolicy("OrderOrAdmin", policy => policy.RequireRole("SuperAdmin", "OrderManager"));
            options.AddPolicy("AnyAdmin", policy => policy.RequireRole("SuperAdmin", "InventoryManager", "OrderManager"));
        });

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Himgiri Goods API",
                Version = "v1",
                Description = "DPS Hinjawadi School Kit Distribution Portal API"
            });

            // Auto-handle the Bearer prefix
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Just paste your token below.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
    {
        // FluentValidation
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Himgiri.Core.Entities.BaseEntity>();

        // Mapster
        services.AddMapster();

        // Hangfire
        services.AddHangfire(h => h
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(options => options.UseNpgsqlConnection(config.GetConnectionString("DefaultConnection"))));
        services.AddHangfireServer();

        // Repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IApiErrorLogRepository, ApiErrorLogRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IGstRateRepository, GstRateRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ISchoolKitRepository, SchoolKitRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        
        // Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IExcelService, ExcelService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IGradeService, GradeService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IGstRateService, GstRateService>();
        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ISchoolKitService, SchoolKitService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<ITaxService, TaxService>();
        
        // Phase 2+ services registered here as built
        return services;
    }
}
