using Serilog;

using Gay.Silverbranch.Api.Models.Entities.V1;

namespace Gay.Silverbranch.Api.Utilities.Backend.Logging.Endpoints.V1;

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
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "{modelName} Model with id:{modelId} was successfully found in the database for USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }

    public static void LogEndpointFailureNullRef(
        Exception ex,
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "{modelName} Model with ID:{modelId} does not exist or " +
                             "USER:{userId} is not allowed to view this data",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        string modelName,
        string modelId,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to get {modelName} Model with ID:{modelId} " +
                             "from the database to respond to call from USER:{userId}",
            propertyValue0: modelName,
            propertyValue1: modelId,
            propertyValue2: callingUserId);
    }
}