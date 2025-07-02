using Gay.Silverbranch.API.Models;
using Serilog;

namespace Gay.Silverbranch.API.Utilities.Backend.Logging.Endpoints.V1;

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
            "Post {modelName} Model Endpoint called by {username}",
            propertyValue0: modelName,
            propertyValue1: callingUserId);
    }
    
    public static void LogEndpointSuccess(
        string id,
        string callingUserId)
    {
        Log.Information(
            messageTemplate: "ModelMetaInfo Model Created with id {id}",
            propertyValue: id);
    }

    public static void LogEndpointFailureServerError(
        Exception ex,
        string callingUserId)
    {
        Log.Error(
            exception: ex,
            messageTemplate: "Server issue encountered while trying to add a new ModelMetaInfo Model to the database");
    }
}