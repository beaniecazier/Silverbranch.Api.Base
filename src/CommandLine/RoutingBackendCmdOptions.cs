using CommandLine;
using Gay.Silverbranch.Api.Utilities.CommandLine;
using Gay.Silverbranch.Api.Utilities.CommandLine.Interface;
using Gay.Silverbranch.API.Utilities.Common.CommandLine;

namespace Gay.Silverbranch.API.Utilities.Backend.CommandLine;

#pragma warning disable CS1591

/// <summary>
/// Full Backend Command Line Options
/// short options
/// h - host
/// p - https port
/// s - subdirectory
/// H - valid host to request health check
/// c - cache expiration timer
/// v - verbose logging/logging level
///
/// long options
/// ready - the readiness probe health check port
/// liveness - the liveness probe health check port
/// startup - the startup probe health check port
/// health-host - 
/// cache-expire - 
/// dbconn - 
/// http - 
/// port - 
/// host - 
/// subdirectory - 
/// verbose - 
/// </summary>
public class RoutingBackendCmdOptions : RoutingCmdOptions, IHealthCheckCmdOptions, ISwaggerInfoCmdOptions
{
#region IHealthCheckCmdOptions Implementations
    
    [Option("ready",
        Default = 5051)]
    public int ReadyCheckPort { get; set; }

    [Option("liveness",
        Default = 5052)]
    public int LivenessCheckPort { get; set; }

    [Option("startup",
        Default = 5050)]
    public int StartupCheckPort { get; set; }

    [Option('H',
        "health-host",
        Required = false,
        Default = "localhost")]
    public string? HealthChecksHostAddress { get; set; } = "*";

    //[Option("startuptime", Default = 10)]
    //public int FakedStartupDurationInSeconds { get; set; }

#endregion
    
#region IHealthCheckCmdOptions Implementations

    [Option(Default = "Tiabeanie Cazier")]
    public string ContactName { get; set; } = "Tiabeanie Cazier";

    [Option(Default = "contact.me@silverbranch.gay")]
    public string ContactEmail { get; set; } = "contact.me@silverbranch.gay";

    [Option(Default = "https://silverbranch.gay/contact")]
    public string ContactUrl { get; set; } = "https://silverbranch.gay/contact";

    [Option(Default = "https://silverbranch.gay/terms")]
    public string TermsOfServiceUrl { get; set; } = "https://silverbranch.gay/terms";

#endregion

    [Option('c',
        "cache-expire",
        Default = 60)]
    public int CacheExpirationTimeInMinutes { get; set; }

    [Option("dbconn")]
    public string? DbConnStr { get; set; }

    //[Option('u', Required = true)]
    //public string BaseUrl {  get; set; }
    
}

#pragma warning restore CS1591