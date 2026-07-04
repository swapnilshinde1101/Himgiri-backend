using Himgiri.API.Extensions;
using Himgiri.API.Middleware;
using Himgiri.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// ── Serilog Configuration ──
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/himgiri-log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// ── Services ──
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSwagger();
builder.Services.AddAppServices(builder.Configuration); // Pass config for Hangfire

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins(
                builder.Configuration["AllowedOrigins"] ?? "http://localhost:5173"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// ── Auto-migrate on startup (dev only) ──
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<HimgiriDbContext>();
    db.Database.Migrate();
}

// ── Middleware pipeline ──
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Himgiri Goods API v1");
    c.RoutePrefix = "swagger";
});

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<ApiAuditLoggingMiddleware>();

app.UseSerilogRequestLogging(); // Structured request logging

app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

// ── Hangfire Dashboard ──
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() } // We'll create this
});

RecurringJob.AddOrUpdate<Himgiri.Core.Interfaces.Services.IOrderService>(
    "cancel-stale-pending-orders",
    service => service.CancelStalePendingOrdersAsync(default),
    Cron.Daily
);

app.MapControllers();

app.Run();
