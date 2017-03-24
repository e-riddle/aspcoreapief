using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

public class ApiActionFilter : IActionFilter
{

    private ILogger _logger;

    public ApiActionFilter(ILoggerFactory loggerFactory)
    {
        if (loggerFactory == null)
        {
            throw new ArgumentNullException(nameof(loggerFactory));
        }

        _logger = loggerFactory.CreateLogger<ApiActionFilter>();

        _logger.LogInformation("Api after request filter has successfully initialized.");

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var headerInfo = this.GetHeaderInfo(context.HttpContext);

       
        var message = $"[TrackingId: {headerInfo.Item1} / User: {headerInfo.Item2}] - Finished request execution.";


        _logger.LogInformation(message);

        
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
       // var headerInfo = this.GetHeaderInfo(context.HttpContext);

       
      //  var message = $"[TrackingId: {headerInfo.Item1} / User: {headerInfo.Item2}] - Executing request...";
        
      // _logger.LogInformation(message);

        //throw new NotImplementedException();
    }

    private Tuple<string,string> GetHeaderInfo(HttpContext context)
    {
          //Refactor this stuff!!!!!
        var trackingId = "Not Provided";

        var authId = "Not Provided";

        StringValues trackingIdValues;

        context.Request.Headers.TryGetValue("TrackingIdProtected", out trackingIdValues);

        StringValues authIdValues;

        context.Request.Headers.TryGetValue("AuthUserProtected", out authIdValues);

        if (trackingIdValues.Any())
            trackingId = trackingIdValues.FirstOrDefault();
        
        if (authIdValues.Any())
            authId = authIdValues.FirstOrDefault();


        return new Tuple<string,string>(string.IsNullOrEmpty(trackingId) ? "Not Provided" : trackingId,
                                         string.IsNullOrEmpty(authId) ? "Not Provided" : authId);
    }


}