using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace aspnetapp.Controllers
{
    [Route("api/v1/[controller]")]
    public class BaseController<T> : Controller
    {
        protected ILogger _logger;

         public BaseController(ILogger<T> logger)
         {
           
            this._logger = logger;
         }

        /// <summary>
        /// For tracking the request.
        /// </summary>
        /// <returns></returns>
        protected string RequestTrackingId 
        {
            get
            {
               
                var trackingId = "Not Provided";

                StringValues trackingIdValues;

                this.HttpContext.Request.Headers.TryGetValue("TrackingIdProtected", out trackingIdValues);

                if (trackingIdValues.Any())
                        trackingId = trackingIdValues.FirstOrDefault();

                return string.IsNullOrEmpty(trackingId) ? "Not Provided" : trackingId;

                
            } 
            set 
            {
                 this.HttpContext.Request.Headers["TrackingIdProtected"] = value;
            }
        }

        ///<summary>
        /// For tracking the user id.
        /// </summary>
        /// <returns></returns>
        protected string AuthUserId {
            get
            {
                    
                    var authId = "Not Provided";

                    StringValues authIdValues;

                    this.HttpContext.Request.Headers.TryGetValue("AuthUserProtected", out authIdValues);
                    
                    if (authIdValues.Any())
                        authId = authIdValues.FirstOrDefault();
                    
                    
                    return string.IsNullOrEmpty(authId) ? "Not Provided" : authId;

                    

            } 
            set 
            {
                 this.HttpContext.Request.Headers["AuthUserProtected"] = value;
            }
        }

        /// <summary>
        /// Gets the tracking ids
        /// </summary>
        /// <param name="requestTrackingId"></param>
        /// <param name="authUserId"></param>
        protected void InitializeRequest (string requestTrackingId, string authUserId)
        {
            this.AuthUserId = authUserId;

            this.RequestTrackingId = requestTrackingId;

            this.LogRequestInformation("Initialized request.");

        }


        protected void LogRequestInformation(string message)
        {
              var fullMessage = $"[TrackingId: {this.RequestTrackingId} / User: {this.AuthUserId}] - {message}";

              this._logger.LogInformation(fullMessage);
        }
          
    }
}