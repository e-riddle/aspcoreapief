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
    public class BaseController : Controller
    {
        
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
                        trackingId = trackingIdValues.FirstOrDefault() ??  "Not Provided";

                return trackingId;

                
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
                        authId = authIdValues.FirstOrDefault() ??  "Not Provided";
                    
                    return authId;

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

        }

        
          
    }
}