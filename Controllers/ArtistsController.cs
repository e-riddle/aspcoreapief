using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetapp.Data.Repository;
using aspnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Controllers
{
    [Route("api/v1/[controller]")]
    public class ArtistsController : BaseController
    {

    
        private readonly ArtistRepository _artistRepository;

        private readonly ILogger _logger;

        
        public ArtistsController(ArtistRepository artistRepository, ILogger<ArtistsController> logger)
        {
           
            this._artistRepository = artistRepository;

            this._logger = logger;
        }

        /// <summary>
        /// Gets me a list of artits
        /// </summary>
        /// <returns>Artists</returns>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="authUserId">Auth user id.</param>
        /// <param name="requestTrackingId">Request tracking id.</param>
        /// <response code="200" >Success</response>
        /// <response code="400">Client Parameter Error</response>
        /// <response code="500">Internal Server Error</response>       
        [HttpGet]
        [ProducesResponseType(typeof(Artist[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<List<Artist>> Get([FromQuery] int page = 1, 
                                            [FromQuery] int pageSize = 15,
                                            [FromHeader] string authUserId = "",
                                            [FromHeader] string requestTrackingId = "")
        {


           
            
            return await this._artistRepository.GetArtists(page, pageSize);
            
            
        }


        [HttpGet("{id}")]
        public async Task<List<Artist>> Get(int id)
        {
             return await this._artistRepository.GetArtist(id);
        }
       
    }
}
