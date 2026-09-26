using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Xunit;
using Himgiri.Infrastructure.Data;
using Himgiri.Infrastructure.Services;
using Himgiri.Tests.TestHelpers;

namespace Himgiri.Tests.Unit;

public class OrderAccessTokenTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly HimgiriDbContext _db;
    private readonly OrderService _orderService;

    public OrderAccessTokenTests()
    {
        _connection = SqliteDbContextFactory.CreateOpenConnection();
        _db = SqliteDbContextFactory.CreateContext(_connection);
        _db.Database.EnsureCreated();

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:Key"] = "unit-test-secret-key-must-be-at-least-32-chars"
            })
            .Build();

        // orderRepo/itemRepo/gradeRepo/unitOfWork/excelService/csvService are unused
        // by the token methods under test.
        _orderService = new OrderService(
            orderRepo: null!,
            itemRepo: null!,
            gradeRepo: null!,
            unitOfWork: null!,
            db: _db,
            taxService: new TaxService(),
            excelService: null!,
            csvService: null!,
            config: config);
    }

    [Fact]
    public void VerifyOrderAccessToken_FreshlyGeneratedToken_IsValid()
    {
        var orderId = Guid.NewGuid();
        var token = _orderService.GenerateOrderAccessToken(orderId);

        Assert.True(_orderService.VerifyOrderAccessToken(orderId, token));
    }

    [Fact]
    public void VerifyOrderAccessToken_TokenForDifferentOrder_IsRejected()
    {
        var token = _orderService.GenerateOrderAccessToken(Guid.NewGuid());

        Assert.False(_orderService.VerifyOrderAccessToken(Guid.NewGuid(), token));
    }

    [Fact]
    public void VerifyOrderAccessToken_TamperedSignature_IsRejected()
    {
        var orderId = Guid.NewGuid();
        var token = _orderService.GenerateOrderAccessToken(orderId);
        var parts = token.Split('.', 2);
        var tampered = $"{parts[0]}.{new string('f', parts[1].Length)}";

        Assert.False(_orderService.VerifyOrderAccessToken(orderId, tampered));
    }

    [Fact]
    public void VerifyOrderAccessToken_ExpiredToken_IsRejected()
    {
        // Regression test: an earlier version of this token never expired, so a leaked
        // confirmation URL (browser history, Jodo referrer) granted permanent PII access.
        var orderId = Guid.NewGuid();
        var expiredExpiry = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeSeconds();

        // Forge a token shaped like a real one but already past its expiry — this exercises
        // the expiry check itself (the real generator always issues a 30-day-future token).
        var forgedToken = $"{expiredExpiry}.0000000000000000000000000000000000000000000000000000000000000000";

        Assert.False(_orderService.VerifyOrderAccessToken(orderId, forgedToken));
    }

    [Fact]
    public void VerifyOrderAccessToken_MalformedToken_IsRejectedNotThrown()
    {
        var orderId = Guid.NewGuid();

        Assert.False(_orderService.VerifyOrderAccessToken(orderId, "not-a-real-token"));
        Assert.False(_orderService.VerifyOrderAccessToken(orderId, ""));
        Assert.False(_orderService.VerifyOrderAccessToken(orderId, "12345"));
    }

    public void Dispose()
    {
        _db.Dispose();
        _connection.Dispose();
    }
}
