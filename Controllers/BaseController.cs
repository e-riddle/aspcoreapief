using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Controllers
{
    [Route("api/v1/[controller]")]
    public class BaseController : Controller
    {
        
        protected string RequestTrackingId 
        {
            get
            {
                return this.HttpContext.Request.Headers["TrackingIdProtected"];
                
            } 
            set 
            {
                 this.HttpContext.Request.Headers["TrackingIdProtected"] = value;
            }
        }

        protected string AuthUserId {
            get
            {
                return this.HttpContext.Request.Headers["AuthUserProtected"];
            } 
            set 
            {
                 this.HttpContext.Request.Headers["AuthUserProtected"] = value;
            }
        }


        protected void InitializeRequest (string requestTrackingId, string authUserId)
        {
            this.AuthUserId = authUserId;

            this.RequestTrackingId = requestTrackingId;

        }
        

          
    }
}