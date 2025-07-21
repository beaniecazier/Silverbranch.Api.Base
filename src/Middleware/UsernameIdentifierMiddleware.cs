using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Gay.Silverbranch.Api.Utilities.Backend.Middleware;

public class UsernameIdentifierMiddleware
{
    public const string Key = "UserNameId";
    
    private readonly RequestDelegate _next;
    private readonly string _userNameIdNotFound = "Username identifier not found in claims";

    public UsernameIdentifierMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        string userNameId = "2d1ba5e0-9d3e-49c9-b2f0-ef4718123f29";
        // string userNameId = context.User.Claims
        //                         .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
        //                     _userNameIdNotFound;
        // if (string.IsNullOrWhiteSpace(userNameId) || userNameId == _userNameIdNotFound)
        // {
        //     await context.Response.WriteAsync(_userNameIdNotFound);
        //     return;
        // }
        
        context.Items.Add(Key, userNameId);
        await _next(context);
    }
}