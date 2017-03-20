using System.Collections.Generic;
using System.Threading.Tasks;
using aspnetapp.Data.Repository;
using aspnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Controllers
{

    public class ArtistController : Controller
    {

    
        private readonly ArtistRepository _artistRepository;

        private readonly ILogger _logger;


        public ArtistController(ArtistRepository artistRepository, ILogger<ArtistController> logger)
        {
           
            this._artistRepository = artistRepository;

            this._logger = logger;
        }

        /// <summary>
        /// Gets me a list of artits
        /// </summary>
        /// <returns>Artists</returns>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Page Size.</param>
        /// <response code="200" >Success</response>
        /// <response code="400">Client Parameter Error</response>
        /// <response code="500">Internal Server Error</response>       
        [HttpGet("api/artists")]
        [ProducesResponseType(typeof(Artist[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<List<Artist>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 15)
        {

            
           
            
            return await this._artistRepository.GetArtists(page, pageSize);
            
            
        }

       
    }
}
