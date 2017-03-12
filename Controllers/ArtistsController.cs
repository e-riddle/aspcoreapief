using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetapp.Data.Models;
using aspnetapp.Data.Repository;
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


        [HttpGet("api/artists")]
        public async Task<List<Artists>> Get()
        {


            this._logger.LogInformation("Getting artists...");

            return await this._artistRepository.GetArtists();

            
        }

       
    }
}
