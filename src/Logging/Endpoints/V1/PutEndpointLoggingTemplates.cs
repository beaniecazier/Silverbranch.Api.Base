using Serilog;

namespace Gay.Silverbranch.Api.Utilities.Backend.Logging.Endpoints.V1;

public class PutEndpointLoggingTemplates
{
    public static void LogAddServices(
        string modelName)
    {
        Log.Information(
            messageTemplate: "The specific services related to the {modelName} Model Put Endpoint are being registered",
            propertyValue: modelName);
    }
    
    public static void LogDefined(
        string modelName)
    {
        Log.Information(
            messageTemplate: "Now adding {modelName} Model Put Endpoint",
            propertyValue: modelName);
    }
    
    public static void LogCalled(
        string modelName,
        string callingUserId)
    {
        Log.Information(
            "Put {modelName} Model Endpoint called by {username}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        string id,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "ModelMetaInfo Model with id:{id} was successfully marked deleted",
            propertyValue: id);
    }

    public static void LogEndpointFailureNullRef(Exception ex, string modelId, string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "ModelMetaInfo Model with ID:{id} does not exist or you are not allowed to view this data",
            propertyValue: modelId);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to update ModelMetaInfo Model with ID:{id} from the database",
            propertyValue: modelId);
    }
}