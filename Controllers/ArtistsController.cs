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
        // GET api/values
        [HttpGet("api/artists")]
        public async Task<List<Artist>> Get()
        {


            this._logger.LogInformation("Getting artists...");
            
            return await this._artistRepository.GetArtists();
            
            
        }

       
    }
}
