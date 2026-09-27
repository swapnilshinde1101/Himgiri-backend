using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using Himgiri.API.Controllers;
using Himgiri.Core.DTOs;
using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Himgiri.Core.Models;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

public class NotificationServiceTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly IConfiguration _config;
    private readonly IDataProtectionProvider _dataProtectionProvider;
    private readonly EmailService _emailService;
    private readonly WhatsAppService _whatsAppService;
    private readonly InvoiceService _invoiceService;
    private readonly OrderService _orderService;
    private readonly OrderNotificationService _notificationService;

    public NotificationServiceTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        var inMemorySettings = new Dictionary<string, string?>
        {
            { "Email:SmtpHost", "smtp.gmail.com" },
            { "Email:SmtpPort", "587" },
            { "Email:SenderEmail", "noreply@himgirigoods.com" },
            { "Email:SenderName", "Himgiri Goods" },
            { "Email:Password", "YOUR_SMTP_PASSWORD" }, // triggers simulated mode
            { "WhatsApp:Enabled", "true" },
            { "WhatsApp:Provider", "Simulated" },
            { "WhatsApp:ApiKey", "YOUR_WHATSAPP_API_KEY" },
            { "Jwt:Key", "TestSecretKeyForOrderAccessTokens1234567890!" },
            { "AllowedOrigins", "http://localhost:5173" },
            { "App:ApiBaseUrl", "https://localhost:62313" }
        };

        _config = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        _dataProtectionProvider = new EphemeralDataProtectionProvider();
        _emailService = new EmailService(_db, _config, NullLogger<EmailService>.Instance, _dataProtectionProvider);
        _whatsAppService = new WhatsAppService(_config, NullLogger<WhatsAppService>.Instance);
        _invoiceService = new InvoiceService(_db);

        _orderService = new OrderService(
            orderRepo: null!,
            itemRepo: null!,
            gradeRepo: null!,
            unitOfWork: null!,
            db: _db,
            taxService: new TaxService(),
            excelService: null!,
            csvService: null!,
            config: _config,
            logger: NullLogger<OrderService>.Instance);

        _notificationService = new OrderNotificationService(
            _db,
            _emailService,
            _whatsAppService,
            _invoiceService,
            _orderService,
            _config,
            NullLogger<OrderNotificationService>.Instance);
    }

    private async Task<Order> CreateTestOrderAsync()
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "HG-2026-0099",
            CustomerName = "Anjali Patil",
            Email = "anjali.patil@example.com",
            Mobile = "9823012345",
            AddressLine1 = "B-102, Green Valley",
            City = "Pune",
            Pincode = "411057",
            GradeName = "Grade 6-B",
            SellerCompanyName = "Himgiri Goods Pvt. Ltd",
            SellerGstin = "27AAACS8577K2ZO",
            SellerAddress = "FC Road, Pune",
            SellerStateName = "Maharashtra",
            SellerGstStateCode = "27",
            CustomerStateName = "Maharashtra",
            CustomerGstStateCode = "27",
            PlaceOfSupply = "Maharashtra",
            PlaceOfSupplyCode = "27",
            SupplyType = SupplyType.IntraState,
            IsHomeDelivery = true,
            SubTotal = 1500m,
            TotalGst = 270m,
            GrandTotal = 1770m,
            Status = OrderStatus.Confirmed,
            PaymentStatus = PaymentStatus.Success,
            CreatedAt = DateTime.UtcNow
        };

        order.Items.Add(new OrderItem
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            ItemId = Guid.NewGuid(),
            ItemName = "School Kit Complete Set",
            HsnCode = "4901",
            Quantity = 1,
            UnitPrice = 1500m,
            BaseAmount = 1500m,
            GstPercent = 18m,
            CgstPercent = 9m,
            SgstPercent = 9m,
            GstAmount = 270m,
            LineTotal = 1770m,
            IsKitItem = true
        });

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }

    [Fact]
    public async Task EmailService_PlaceholderCredentials_RunsInSimulatedModeSuccessfully()
    {
        var result = await _emailService.SendEmailAsync("test@example.com", "Test Subject", "<p>Body</p>");
        Assert.True(result);
    }

    [Fact]
    public async Task EmailService_EmptyRecipient_ReturnsFalse()
    {
        var result = await _emailService.SendEmailAsync("", "Test Subject", "<p>Body</p>");
        Assert.False(result);
    }

    [Fact]
    public async Task WhatsAppService_SimulatedProvider_RunsSuccessfully()
    {
        var result = await _whatsAppService.SendWhatsAppMessageAsync("9823012345", "Test WhatsApp notification");
        Assert.True(result);
    }

    [Fact]
    public async Task WhatsAppService_EmptyMobile_ReturnsFalse()
    {
        var result = await _whatsAppService.SendWhatsAppMessageAsync("", "Test Message");
        Assert.False(result);
    }

    [Fact]
    public async Task SendOrderConfirmationAsync_OrderNotFound_Returns404()
    {
        var result = await _notificationService.SendOrderConfirmationAsync(Guid.NewGuid());
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public async Task SendOrderConfirmationAsync_ValidOrder_SendsNotificationsAndLogsHistory()
    {
        var order = await CreateTestOrderAsync();

        var result = await _notificationService.SendOrderConfirmationAsync(order.Id);

        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Data);

        // Verify notification entry logged in OrderStatusHistories
        var history = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(
            _db.OrderStatusHistories,
            h => h.OrderId == order.Id && h.ChangedBy == "Notification Service");

        Assert.NotNull(history);
        Assert.Contains("confirmation notification dispatched", history.Note);
    }

    [Fact]
    public async Task SendOrderDispatchedAsync_ValidOrder_SendsDispatchNotificationsAndLogsHistory()
    {
        var order = await CreateTestOrderAsync();

        var result = await _notificationService.SendOrderDispatchedAsync(order.Id);

        Assert.Equal(200, result.StatusCode);
        Assert.True(result.Data);

        var history = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(
            _db.OrderStatusHistories,
            h => h.OrderId == order.Id && h.ChangedBy == "Notification Service");

        Assert.NotNull(history);
        Assert.Contains("Dispatch notification", history.Note);
    }

    [Fact]
    public async Task EmailSettingsController_GetSettings_ReturnsDefaultOrExistingConfig()
    {
        var controller = new EmailSettingsController(_db, _emailService, _dataProtectionProvider);

        var result = await controller.GetSettings(default);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var jsonModel = Assert.IsType<JsonModel<EmailSettingsDto>>(okResult.Value);
        Assert.NotNull(jsonModel.Data);
        Assert.Equal("smtp.gmail.com", jsonModel.Data.SmtpHost);
        Assert.Equal(587, jsonModel.Data.SmtpPort);
    }

    [Fact]
    public async Task EmailSettingsController_UpdateSettings_UpdatesDbSuccessfully()
    {
        var controller = new EmailSettingsController(_db, _emailService, _dataProtectionProvider);

        var request = new UpdateEmailSettingsRequest(
            SmtpHost: "smtp.sendgrid.net",
            SmtpPort: 587,
            SenderEmail: "orders@himgirigoods.com",
            SenderName: "Himgiri Orders",
            SmtpPassword: "SG.actual_secret_token_12345",
            EnableSsl: true,
            IsConfigured: true
        );

        var result = await controller.UpdateSettings(request, default);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var jsonModel = Assert.IsType<JsonModel<EmailSettingsDto>>(okResult.Value);
        Assert.NotNull(jsonModel.Data);
        Assert.Equal("smtp.sendgrid.net", jsonModel.Data.SmtpHost);
        Assert.Equal("orders@himgirigoods.com", jsonModel.Data.SenderEmail);
        Assert.True(jsonModel.Data.HasPassword);
        Assert.True(jsonModel.Data.IsConfigured);
    }

    [Fact]
    public async Task EmailSettingsController_TestConnection_RejectsInvalidEmail()
    {
        var controller = new EmailSettingsController(_db, _emailService, _dataProtectionProvider);

        var request = new TestEmailRequest("invalid-email-format");
        var result = await controller.TestConnection(request, default);

        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        var jsonModel = Assert.IsType<JsonModel<object>>(badRequest.Value);
        Assert.Contains("valid recipient email", jsonModel.Message);
    }

    [Theory]
    [InlineData("127.0.0.1")]        // loopback
    [InlineData("10.0.0.5")]         // RFC1918 private
    [InlineData("192.168.1.1")]      // RFC1918 private
    [InlineData("169.254.169.254")]  // link-local / cloud metadata endpoint
    public async Task SendTestEmailAsync_PrivateOrInternalHost_IsBlocked(string internalHost)
    {
        var (success, message) = await _emailService.SendTestEmailAsync(
            toEmail: "someone@example.com",
            smtpHost: internalHost,
            smtpPort: 25,
            senderEmail: "sender@example.com",
            senderName: "Test Sender",
            smtpPassword: "somepassword",
            enableSsl: false);

        Assert.False(success);
        Assert.Contains("private/internal address", message);
    }

    [Fact]
    public async Task SendEmailAsync_ConfiguredWithPrivateHost_IsBlockedAndReturnsFalse()
    {
        var controller = new EmailSettingsController(_db, _emailService, _dataProtectionProvider);
        await controller.UpdateSettings(new UpdateEmailSettingsRequest(
            SmtpHost: "10.0.0.9",
            SmtpPort: 587,
            SenderEmail: "orders@himgirigoods.com",
            SenderName: "Himgiri Orders",
            SmtpPassword: "RealLookingSecret123",
            EnableSsl: true,
            IsConfigured: true
        ), default);

        var result = await _emailService.SendEmailAsync("customer@example.com", "Subject", "<p>Body</p>");

        Assert.False(result);
    }

    [Fact]
    public async Task EmailSettingsController_UpdateSettings_EncryptsPasswordAtRest()
    {
        var controller = new EmailSettingsController(_db, _emailService, _dataProtectionProvider);

        var request = new UpdateEmailSettingsRequest(
            SmtpHost: "smtp.sendgrid.net",
            SmtpPort: 587,
            SenderEmail: "orders@himgirigoods.com",
            SenderName: "Himgiri Orders",
            SmtpPassword: "MySuperSecretPassword123",
            EnableSsl: true,
            IsConfigured: true
        );

        await controller.UpdateSettings(request, default);

        var stored = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.FirstAsync(
            _db.EmailConfigurations, c => !c.IsDeleted);

        // The DB column must never hold the raw secret...
        Assert.NotEqual("MySuperSecretPassword123", stored.SmtpPassword);
        Assert.NotEmpty(stored.SmtpPassword);

        // ...but it must decrypt back to the original value via the same protector EmailService uses.
        var decrypted = _dataProtectionProvider
            .CreateProtector("Himgiri.EmailSettings.SmtpPassword")
            .Unprotect(stored.SmtpPassword);
        Assert.Equal("MySuperSecretPassword123", decrypted);
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
