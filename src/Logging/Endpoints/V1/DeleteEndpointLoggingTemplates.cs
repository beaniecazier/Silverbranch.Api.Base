using Serilog;

using Gay.Silverbranch.API.Models.Entities.V1;

namespace Gay.Silverbranch.API.Utilities.Backend.Logging.Endpoints.V1;

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
            "Delete {modelName} Model Endpoint called by {username}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(BaseModel model)
    {
        Log.Information(
            messageTemplate: "ModelMetaInfo Model with id:{id} was successfully marked deleted",
            propertyValue: model.CommonIdentity);
    }

    public static void LogEndpointFailureNullRef(Exception ex, string modelId, string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "ModelMetaInfo Model with ID:{id} does not exist",
            propertyValue: modelId);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to delete ModelMetaInfo Model with ID:{id} from the database",
            propertyValue: modelId);
    }
}