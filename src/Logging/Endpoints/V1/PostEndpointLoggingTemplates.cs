using Serilog;

namespace Gay.Silverbranch.Api.Utilities.Backend.Logging.Endpoints.V1;

public class PostEndpointLoggingTemplates
{
    public static void LogAddServices(string modelName)
    {
        Log.Information(
            messageTemplate: "The specific services related to the {modelName} Model Post Endpoint are being registered",
            propertyValue: modelName);
    }
    
    public static void LogDefined(string modelName)
    {
        Log.Information(
            messageTemplate: "Now adding {modelName} Model Post Endpoint",
            propertyValue: modelName);
    }
    
    public static void LogCalled(
        string modelName,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "Post {modelName} Model Endpoint called by USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "Successfully created new {modelName} Model with ID:{modelId} for request by USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }

    public static void LogEndpointFailureServerError(
        Exception exception,
        string callingUserId,
        string modelName)
    {
        Log.Error(
            exception: exception,
            messageTemplate: "Server issue encountered while trying to add a new {modelName} Model " +
                             "to the database by request of USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
}