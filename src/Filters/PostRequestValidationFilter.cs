using FluentValidation;
using FluentValidation.Results;
using Gay.Silverbranch.API.Utilities.Contract.Requests;
using Gay.Silverbranch.API.Utilities.Contract.Requests.V1;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Gay.Silverbranch.API.Utilities.Backend.Filters;

public abstract class PostRequestValidationFilter<T> : IEndpointFilter
where T : PostBaseModelRequest
{
    protected readonly IValidator<T> _requestValidator;

    public PostRequestValidationFilter(
        IValidator<T> requestValidator)
    {
        _requestValidator = requestValidator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.Arguments
            .OfType<T>()
            .FirstOrDefault();
        if (request is null)
            return Results.BadRequest("Missing or invalid request body");
        
        var result = await PreEndpointFilterActionAsync(context, request);

        if (result is null) return Results.BadRequest("Invalid request body, validation failed and returned null");
        if (!result.IsValid)
        {
            foreach (var error in result.Errors) Log.Fatal(error.ToString());
            return Results.BadRequest(result.Errors);
        }
        
        var response = await next(context);
        return await PostEndpointFilterActionAsync(context, response);
    }

    protected virtual async Task<ValidationResult?> PreEndpointFilterActionAsync(
        EndpointFilterInvocationContext context,
        T request)
    {
        return await _requestValidator.ValidateAsync(request);
    }

    protected abstract ValueTask<object?> PostEndpointFilterActionAsync(
        EndpointFilterInvocationContext context,
        object? response);
}