using Gay.Silverbranch.Api.Bll.Options.V1;
using Serilog;

namespace Gay.Silverbranch.Api.Utilities.Backend.Logging.Endpoints.V1;

public class GetAllEndpointLoggingTemplates
{
    public static void LogAddServices(string modelName)
    {
        Log.Information(
            messageTemplate: "The specific services related to the {modelName} Model GetAll Endpoint are being registered",
            propertyValue: modelName);
    }
    
    public static void LogDefined(string modelName)
    {
        Log.Information(
            messageTemplate: "Now adding {modelName} Model GetAll Endpoint",
            propertyValue: modelName);
    }
    
    public static void LogCalled(
        string modelName,
        string callingUserId)
    {
        Log.Information(
            "GetAll {modelName} Model Endpoint called by {username}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        int totalNumberOfResponses,
        GetAllModelsOptions options)
    {
        Log.Information(
            messageTemplate: "Found {count} ModelMetaInfo Models matching request {request}}",
            propertyValue0: totalNumberOfResponses,
            propertyValue1: options);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        GetAllModelsOptions options)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to get all ModelMetaInfo Models from the database that matched request {request}",
            propertyValue: options);
    }
}