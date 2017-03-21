using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Controllers
{
    [Route("api/v1/[controller]")]
    public class ValuesController : BaseController<ValuesController>
    {

         public ValuesController(ILogger<ValuesController> logger) : base (logger) {}
           
         /// <summary>
        /// Get me some values
        /// </summary>
        /// <returns>string</returns>
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get(
                                        [FromHeader] string authUserId = "",
                                        [FromHeader] string requestTrackingId = "")
        {

            this.InitializeRequest(requestTrackingId, authUserId);


            var values =  new string[] { "value1", "value2" };



            return values;


            
        }

        /// <summary>
        /// Get me a value by id.
        /// </summary>
        /// <param name="id">Id of the value.</param>
        /// <returns>A value.</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id,  [FromHeader] string authUserId = "",
                                        [FromHeader] string requestTrackingId = "")
        {

            //throw new Exception("Bad id");
            this.InitializeRequest(requestTrackingId, authUserId);
            

            throw new BadRequestException("Bad id");


            //return "value";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
