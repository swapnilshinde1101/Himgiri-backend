namespace Himgiri.Core.Entities;

public class State : BaseEntity
{
    public string StateCode { get; set; } = string.Empty;     // E.g. "MH", "KA", "DL"
    public string StateName { get; set; } = string.Empty;     // E.g. "Maharashtra", "Karnataka", "Delhi"
    public string GstStateCode { get; set; } = string.Empty;  // Official 2-digit GST code (e.g. "27", "29", "07")
    public bool IsUnionTerritory { get; set; } = false;
}
