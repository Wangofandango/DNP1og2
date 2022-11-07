using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            
            //Her tilføjer man policies som senere kan henvises til via "name". Dog har jeg ikke brug for nogen specifikke policies
            //Dette kunne dog være hvis man havde et moderator system, så skulle man kunne slette alle posts. 
            
        });
    }
}