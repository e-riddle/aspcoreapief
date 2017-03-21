using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

public class ApiExceptionFilter : IExceptionFilter
{

    private ILogger _logger;

    public ApiExceptionFilter(ILoggerFactory loggerFactory)
    {
        if (loggerFactory == null)
        {
            throw new ArgumentNullException(nameof(loggerFactory));
        }

        _logger = loggerFactory.CreateLogger<ApiExceptionFilter>();

        _logger.LogInformation("Api exception filter has successfully initialized.");

    }

    public void OnException(ExceptionContext context)
    {
        
        var status = StatusCodes.Status500InternalServerError;
        String message = String.Empty;


        var exceptionType = context.Exception.GetType();
        if (exceptionType == typeof(UnauthorizedAccessException))
        {
            message = "Unauthorized Access";
            status = StatusCodes.Status401Unauthorized;
        }
        else if (exceptionType == typeof(NotImplementedException))
        {
            message = "A server error occurred.";
            status = StatusCodes.Status501NotImplemented;
        }
        else if (exceptionType == typeof(BadRequestException))
        {
            message = "The request is invalid.";
            status = StatusCodes.Status400BadRequest;
        }
        else 
        {
            message = context.Exception.ToString();
            status = StatusCodes.Status500InternalServerError;
        }
       

        HttpResponse response = context.HttpContext.Response;
        response.StatusCode = (int)status;
        response.ContentType = "application/json";

        //var err = message + " " + context.Exception.StackTrace;

        
        //Refactor this stuff!!!!!
        var trackingId = "Not Provided";

        var authId = "Not Provided";

        StringValues trackingIdValues;

        context.HttpContext.Request.Headers.TryGetValue("TrackingIdProtected", out trackingIdValues);

        StringValues authIdValues;

        context.HttpContext.Request.Headers.TryGetValue("AuthUserProtected", out authIdValues);

        if (trackingIdValues.Any())
            trackingId = trackingIdValues.FirstOrDefault() ??  "Not Provided";
        
        if (authIdValues.Any())
            authId = authIdValues.FirstOrDefault() ??  "Not Provided";
        


        var err = $"[TrackingId: {trackingId} / User: {authId}] - {message} {context.Exception.StackTrace}";

        _logger.LogError(err);


        if (response.StatusCode == 500)
        {
            response.WriteAsync("Please contact technical support.");
        } 
        else 
        {
            response.WriteAsync(message);
        }


    }
}