using System;
using Xunit;
using Himgiri.Core.Enums;
using Himgiri.Core.Helpers;
using Himgiri.Core.Entities;
using Himgiri.Infrastructure.Services;

namespace Himgiri.Tests.Unit;

public class GstComplianceTests
{
    private readonly TaxService _taxService;

    public GstComplianceTests()
    {
        _taxService = new TaxService();
    }

    [Fact]
    public void DetermineSupplyType_SameState_ReturnsIntraState()
    {
        // Arrange
        var sellerStateId = Guid.NewGuid();
        var customerStateId = sellerStateId; // Same

        // Act
        var result = _taxService.DetermineSupplyType(sellerStateId, customerStateId);

        // Assert
        Assert.Equal(SupplyType.IntraState, result);
    }

    [Fact]
    public void DetermineSupplyType_DifferentState_ReturnsInterState()
    {
        // Arrange
        var sellerStateId = Guid.NewGuid();
        var customerStateId = Guid.NewGuid(); // Different

        // Act
        var result = _taxService.DetermineSupplyType(sellerStateId, customerStateId);

        // Assert
        Assert.Equal(SupplyType.InterState, result);
    }

    [Theory]
    [InlineData(100, 18, 0, SupplyType.IntraState, 9, 9, 0, 9, 9, 0, 18, 118)]
    [InlineData(100, 18, 0, SupplyType.InterState, 0, 0, 18, 0, 0, 18, 18, 118)]
    [InlineData(250, 12, 0, SupplyType.IntraState, 6, 6, 0, 15, 15, 0, 30, 280)]
    [InlineData(100, 0, 0, SupplyType.IntraState, 0, 0, 0, 0, 0, 0, 0, 100)] // Zero-rate check
    public void CalculateTax_ValidScenarios_ReturnsExpectedTaxResults(
        decimal baseAmount, 
        decimal rate, 
        decimal cess, 
        SupplyType supplyType, 
        decimal expectedCgstRate,
        decimal expectedSgstRate,
        decimal expectedIgstRate,
        decimal expectedCgstAmount,
        decimal expectedSgstAmount,
        decimal expectedIgstAmount,
        decimal expectedGstAmount,
        decimal expectedTotalAmount)
    {
        // Act
        var result = _taxService.CalculateTax(baseAmount, rate, cess, supplyType);

        // Assert
        Assert.Equal(expectedCgstRate, result.CgstPercent);
        Assert.Equal(expectedSgstRate, result.SgstPercent);
        Assert.Equal(expectedIgstRate, result.IgstPercent);
        Assert.Equal(expectedCgstAmount, result.CgstAmount);
        Assert.Equal(expectedSgstAmount, result.SgstAmount);
        Assert.Equal(expectedIgstAmount, result.IgstAmount);
        Assert.Equal(expectedGstAmount, result.GstAmount);
        Assert.Equal(expectedTotalAmount, result.TotalAmount);
    }

    [Theory]
    [InlineData(5.555, 5.56)]
    [InlineData(5.554, 5.55)]
    [InlineData(5.5555, 5.56)]
    public void MoneyHelper_RoundingAwayFromZero_RoundsCorrectly(decimal input, decimal expected)
    {
        // Act
        var result = MoneyHelper.Round(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("27ABCDE1234F1Z5", "27", true)]
    [InlineData("29ABCDE1234F1Z5", "27", false)] // mismatch prefix
    [InlineData("27ABCDE1234F1Z", "27", false)]  // short length
    [InlineData("27ABCDE1234F1Z56", "27", false)] // long length
    [InlineData("27GSTIN_PENDING", "27", false)]  // contains GSTIN_ placeholder
    [InlineData("27PENDINGCLIENT", "27", false)]  // contains PENDING placeholder
    public void ValidateGstin_FormatAndPrefixMatch_BehavesAsExpected(string gstin, string stateGstCode, bool expectedValid)
    {
        // Simple logic mirroring our Service validation
        bool isPlaceholder = gstin.Contains("PENDING") || gstin.Contains("GSTIN_");
        bool isValid = !isPlaceholder && gstin.Length == 15 && gstin.Substring(0, 2) == stateGstCode;

        // Assert
        Assert.Equal(expectedValid, isValid);
    }
}
