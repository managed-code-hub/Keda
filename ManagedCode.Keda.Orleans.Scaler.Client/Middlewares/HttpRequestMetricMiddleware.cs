using ManagedCode.Keda.Orleans.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Orleans;

namespace ManagedCode.Keda.Orleans.Scaler.Client.Middlewares;

public class HttpRequestMetricMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IClusterClient _clusterClient;
    private readonly ILogger<HttpRequestMetricMiddleware> _logger;

    public HttpRequestMetricMiddleware(ILogger<HttpRequestMetricMiddleware> logger, IClusterClient clusterClient, RequestDelegate next)
    {
        _logger = logger;
        _clusterClient = clusterClient;
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        _clusterClient.GetGrain<IRequestTrackerGrain>(0).TrackRequest().Ignore();
        await _next(httpContext);
    }
}
