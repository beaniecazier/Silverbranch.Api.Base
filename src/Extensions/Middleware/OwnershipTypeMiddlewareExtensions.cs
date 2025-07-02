using Gay.Silverbranch.API.Utilities.Backend.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Gay.Silverbranch.API.Utilities.Backend.Extensions.Middleware;

public static class OwnershipTypeMiddlewareExtensions
{
    public static IApplicationBuilder UseOwnershipTypeFlaging(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<OwnershipTypeMiddleware>();
    }
}