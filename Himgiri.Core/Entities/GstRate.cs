using System;

namespace Himgiri.Core.Entities;

/// <summary>
/// Master Tax table defining HSN codes and active GST/CESS percentages over time.
/// </summary>
public class GstRate : BaseEntity
{
    public string Name { get; set; } = string.Empty;              // E.g. "GST 18%", "Books Exempt"
    public string HsnCode { get; set; } = string.Empty;           // Note: HsnCode is NOT unique
    public string? Description { get; set; }
    public decimal Rate { get; set; }                             // Total GST percentage (e.g., 18.00)
    public decimal Cgst { get; set; }                             // Central GST percentage (e.g., 9.00)
    public decimal Sgst { get; set; }                             // State GST percentage (e.g., 9.00)
    public decimal Igst { get; set; }                             // Integrated GST percentage (e.g., 18.00)
    public decimal Cess { get; set; } = 0.00m;                    // Compensation Cess percentage (e.g., 0.00)
    public DateTime EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
}
