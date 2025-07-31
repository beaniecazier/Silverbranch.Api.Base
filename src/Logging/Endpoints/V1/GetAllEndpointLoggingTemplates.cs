using Gay.Silverbranch.Api.Bll.Options.V1;
using Serilog;

namespace Gay.Silverbranch.Api.Utilities.Backend.Logging.Endpoints.V1;

public class GetAllEndpointLoggingTemplates
{
    public static void LogAddServices(
        string modelName)
    {
        Log.Information(
            messageTemplate: "The specific services related to the {modelName} Model GetAll Endpoint are being registered",
            propertyValue: modelName);
    }
    
    public static void LogDefined(
        string modelName)
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
            messageTemplate: "GetAll {modelName} Model Endpoint called by USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        string modelName,
        GetAllModelsOptions options,
        int totalNumberOfResponses,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "Found {count} {modelName} Models matching request {request} made by USER:{userId}",
            totalNumberOfResponses,
            modelName,
            options,
            callingUserId);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        string modelName,
        GetAllModelsOptions options,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to get all {modelName} Models from the database " +
                             "that matched request {request} made by USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: options,
            propertyValue2: callingUserId);
    }
}