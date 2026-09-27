namespace Himgiri.Core.Security;

// "Purpose" strings for the ASP.NET Core Data Protection API. Everywhere a protector is created for
// the same encrypted value MUST use the exact same purpose string, or Unprotect silently fails
// (different purpose => different derived key). Centralized here instead of duplicated as string
// literals so EmailService and EmailSettingsController can never drift apart.
public static class DataProtectionPurposes
{
    public const string EmailSmtpPassword = "Himgiri.EmailSettings.SmtpPassword";
}
