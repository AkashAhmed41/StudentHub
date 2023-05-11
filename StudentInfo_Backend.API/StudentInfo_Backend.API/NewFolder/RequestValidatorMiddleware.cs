using System.Net;
using System.Text.RegularExpressions;

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
        if (!IsValidRequest(context.Request))
        {
            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            await context.Response.WriteAsync("Invalid request method!");
            return;
        }

        await _next(context);
    }

    private bool IsValidRequest(HttpRequest request)
    {
        string apiMethodPath = request.Path;
        HttpMethod requestedMethod = new HttpMethod(request.Method);
        HttpMethod allowedMethod = GetAllowedMethod(apiMethodPath);

        if (requestedMethod != allowedMethod)
        {
            return false;
        }

        return true;
    }

    private HttpMethod GetAllowedMethod(string apiMethodPath)
    {
        string actionName = apiMethodPath.Split('/')[3];
        Match match = Regex.Match(actionName, @"^[A-Z][a-z]+(?=[A-Z][a-z])");
        string methodName = match.Value;

        switch (methodName)
        {
            case "Add":
                return HttpMethod.Post;
            case "Get":
                return HttpMethod.Get;
            case "Update":
                return HttpMethod.Put;
            case "Delete":
                return HttpMethod.Delete;
            default:
                return null;
        }
    }
}

