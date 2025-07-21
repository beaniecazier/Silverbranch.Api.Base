using Serilog;

using Gay.Silverbranch.API.Models.Entities.V1;

namespace Gay.Silverbranch.API.Utilities.Backend.Logging.Endpoints.V1;

public class GetByIdEndpointLoggingTemplates
{
    public static void LogAddServices(string modelName)
    {
        Log.Information(
            messageTemplate: "The specific services related to the {modelName} Model GetById Endpoint are being registered",
            propertyValue: modelName);
    }
    
    public static void LogDefined(string modelName)
    {
        Log.Information(
            messageTemplate: "Now adding {modelName} Model GetById Endpoint",
            propertyValue: modelName);
    }
    
    public static void LogCalled(
        string modelName,
        string callingUserId)
    {
        Log.Information(
            "GetById {modelName} Model Endpoint called by {username}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        BaseModel model,
        string callingUserId)
    {
        Log.Information(
            "ModelMetaInfo Model with id:{Succ.CommonIdentity} was successfully found in the database",
            model.CommonIdentity);
    }

    public static void LogEndpointFailureNullRef(
        Exception ex,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Model with ID:{@id} does not exist, or you are not allowed to view this data",
            propertyValue: modelId);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to get ModelMetaInfo Model with ID:{id} from the database",
            propertyValue: modelId);
    }
}