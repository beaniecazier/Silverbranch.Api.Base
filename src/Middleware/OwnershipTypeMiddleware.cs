using Microsoft.AspNetCore.Http;
using System.Security.Claims;

using Gay.Silverbranch.Api.Models.Enum.V1;
using Gay.Silverbranch.Utilities.Security.Constants;

namespace Gay.Silverbranch.Api.Utilities.Backend.Middleware;

public class OwnershipTypeMiddleware
{
    public const string Key = "OwnershipType";
    
    private readonly RequestDelegate _next;
    //private readonly string

    public OwnershipTypeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ownershipType = eModelOwnershipScope.All;
        // var ownershipType = eModelOwnershipScope.Self;
        // var identity = context.User.Identity as ClaimsIdentity;
        //
        // if (identity!.HasClaim(ClaimTypes.Role, AuthConstants.TrustedMemberPolicyName) ||
        //     identity!.HasClaim(ClaimTypes.Role, AuthConstants.AdminUserPolicyName))
        // {
        //     ownershipType = eModelOwnershipScope.All;
        // }
        
        context.Items.Add(Key, ownershipType);
        await _next(context);
    }
}