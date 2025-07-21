using Gay.Silverbranch.Api.Utilities.Backend.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Gay.Silverbranch.Api.Utilities.Backend.Extensions.Middleware;

public static class UsernameIdentifierMiddlewareExtensions
{
    public static IApplicationBuilder UseUsernameIdentifierMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UsernameIdentifierMiddleware>();
    }
}