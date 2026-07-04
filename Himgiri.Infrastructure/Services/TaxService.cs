using System;
using Himgiri.Core.Enums;
using Himgiri.Core.Helpers;
using Himgiri.Core.Interfaces.Services;

namespace Himgiri.Infrastructure.Services;

public class TaxService : ITaxService
{
    public SupplyType DetermineSupplyType(Guid sellerStateId, Guid customerStateId)
    {
        return sellerStateId == customerStateId ? SupplyType.IntraState : SupplyType.InterState;
    }

    public TaxResult CalculateTax(
        decimal taxableValue, 
        decimal gstPercent, 
        decimal cessPercent, 
        SupplyType supplyType
    )
    {
        decimal roundedBaseAmount = MoneyHelper.Round(taxableValue);
        decimal roundedGstPercent = MoneyHelper.Round(gstPercent);
        decimal roundedCessPercent = MoneyHelper.Round(cessPercent);

        decimal cgstPercent = 0m;
        decimal sgstPercent = 0m;
        decimal igstPercent = 0m;

        decimal cgstAmount = 0m;
        decimal sgstAmount = 0m;
        decimal igstAmount = 0m;

        decimal gstAmount = MoneyHelper.Round(roundedBaseAmount * (roundedGstPercent / 100m));
        decimal cessAmount = MoneyHelper.Round(roundedBaseAmount * (roundedCessPercent / 100m));

        if (supplyType == SupplyType.IntraState)
        {
            cgstPercent = MoneyHelper.Round(roundedGstPercent / 2m);
            sgstPercent = cgstPercent; // Identical rate split

            cgstAmount = MoneyHelper.Round(roundedBaseAmount * (cgstPercent / 100m));
            sgstAmount = gstAmount - cgstAmount;  // absorbs the rounding remainder
        }
        else
        {
            igstPercent = roundedGstPercent;
            igstAmount = gstAmount;
        }

        decimal totalAmount = roundedBaseAmount + gstAmount + cessAmount;

        return new TaxResult(
            GstPercent: roundedGstPercent,
            CgstPercent: cgstPercent,
            SgstPercent: sgstPercent,
            IgstPercent: igstPercent,
            CessPercent: roundedCessPercent,
            BaseAmount: roundedBaseAmount,
            GstAmount: gstAmount,
            CgstAmount: cgstAmount,
            SgstAmount: sgstAmount,
            IgstAmount: igstAmount,
            CessAmount: cessAmount,
            TotalAmount: totalAmount
        );
    }
}
