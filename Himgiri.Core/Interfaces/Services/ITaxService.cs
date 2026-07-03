using System;
using Himgiri.Core.Enums;

namespace Himgiri.Core.Interfaces.Services;

public interface ITaxService
{
    SupplyType DetermineSupplyType(Guid sellerStateId, Guid customerStateId);
    
    TaxResult CalculateTax(
        decimal taxableValue, 
        decimal gstPercent, 
        decimal cessPercent, 
        SupplyType supplyType, 
        bool isCustomerUnionTerritory
    );
}

public record TaxResult(
    decimal GstPercent,
    decimal CgstPercent,
    decimal SgstPercent,
    decimal IgstPercent,
    decimal CessPercent,
    decimal BaseAmount,
    decimal GstAmount,
    decimal CgstAmount,
    decimal SgstAmount,
    decimal IgstAmount,
    decimal CessAmount,
    decimal TotalAmount
);
