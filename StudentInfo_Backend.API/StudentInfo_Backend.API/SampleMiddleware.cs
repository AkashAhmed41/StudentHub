using static System.Net.Mime.MediaTypeNames;

namespace StudentInfo_Backend.API;

public class SampleMiddleware
{
    private readonly ILogger<SampleMiddleware> _logger;
    private readonly RequestDelegate _next;
    public SampleMiddleware(ILogger<SampleMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation("Inside the middleware!");
        var start = DateTime.UtcNow;
        await _next.Invoke(context);
        _logger.LogInformation($"SampleMiddleware {context.Request.Path}: {(DateTime.UtcNow - start).TotalMilliseconds}");
    }
}

public static class SampleMiddlewareExtension
{
    public static IApplicationBuilder UseSampleMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<SampleMiddleware>();
    }
}

