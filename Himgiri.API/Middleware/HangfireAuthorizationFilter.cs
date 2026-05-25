using Hangfire.Dashboard;

namespace Himgiri.API.Middleware;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        // In a professional setup, you'd check for SuperAdmin role
        // For now, we allow access if the user is authenticated (we'll tighten this later)
        return httpContext.User.Identity?.IsAuthenticated ?? false;
    }
}
