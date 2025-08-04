using Serilog;

using Gay.Silverbranch.Api.Models.Entities.V1;

namespace Gay.Silverbranch.Api.Utilities.Backend.Logging.Endpoints.V1;

public class DeleteEndpointLoggingTemplates
{
    public static void LogAddServices(string modelName)
    {
        Log.Information(
            messageTemplate: "The specific services related to the {modelName} Model Delete Endpoint are being registered",
            propertyValue: modelName);
    }
    
    public static void LogDefined(string modelName)
    {
        Log.Information(
            messageTemplate: "Now adding {modelName} Model Delete Endpoint",
            propertyValue: modelName);
    }
    
    public static void LogCalled(
        string modelName,
        string callingUserId)
    {
        Log.Information(
            "Delete {modelName} Model Endpoint called by USER:{userid}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "{modelName} Model with ID:{modelId} was successfully marked deleted by USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }

    public static void LogEndpointFailureNullRef(
        Exception exception,
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: exception,
            messageTemplate: "{modelName} Model with ID:{modelId} does not exist or " +
                             "USER:{userId} is not allowed to view this data",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }

    public static void LogEndpointFailureServerError(
        Exception exception,
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: exception,
            messageTemplate: "Server issue encountered while trying to delete {modelName} Model with ID:{modelId} " +
                             "from the database to respond to call from USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }
}