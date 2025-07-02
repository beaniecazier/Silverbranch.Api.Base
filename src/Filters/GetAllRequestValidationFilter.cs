using FluentValidation;
using Gay.Silverbranch.API.Utilities.Contract.Requests;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Gay.Silverbranch.API.Utilities.Backend.Filters;

public class GetAllRequestValidationFilter : IEndpointFilter
{
    private readonly IValidator<GetAllModelsRequest> _requestValidator;

    public GetAllRequestValidationFilter(
        IValidator<GetAllModelsRequest> validator)
    {
        _requestValidator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var request = context.Arguments
            .OfType<GetAllModelsRequest>()
            .FirstOrDefault();
        if (request is null)
            return Results.BadRequest("Missing or invalid request body");
        
        var result = await _requestValidator.ValidateAsync(request);
        
        if (!result.IsValid)
        {
            foreach (var error in result.Errors) Log.Error(error.ToString());
            return Results.BadRequest(result.Errors);
        }

        return await next(context);
    }
}