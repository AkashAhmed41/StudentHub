using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Routing;

namespace StudentInfo_Backend.API.NewFolder;

public class RequestValidatorMiddleware
{
    private readonly RequestDelegate _next;

    public RequestValidatorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!IsValidRequest(context))
        {
            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            await context.Response.WriteAsync("Invalid request method!");
            return;
        }

        await _next(context);
    }

    private bool IsValidRequest(HttpContext context)
    {
        var routeData = context.GetRouteData();
        var requestedMethod = context.Request.Method;
        var allowedMethod = GetAllowedMethod(routeData);

        if (requestedMethod != allowedMethod)
        {
            return false;
        }

        return true;
    }

    private string GetAllowedMethod(RouteData routeData)
    {
        var endpointMethod = routeData?.Values["action"]?.ToString();
        var controllerName = routeData?.Values["controller"]?.ToString();
        var controllerType = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name == $"{controllerName}Controller");
        if (controllerType == null)
        {
            return null;
        }
        var methodInfo = controllerType.GetMethod(endpointMethod);
        var methodName = methodInfo.GetCustomAttribute<HttpMethodAttribute>().HttpMethods.FirstOrDefault();
        return methodName;
    }
}

