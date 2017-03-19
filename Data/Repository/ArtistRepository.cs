using System;
using System.Collections.Generic;
using System.Text;
using aspnetapp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using aspnetapp.Models;

namespace aspnetapp.Data.Repository
{
    public class ArtistRepository : EfRepositoryBase<AlbumsContext, Artists>
    {
        public ArtistRepository(AlbumsContext context)
            : base(context)
        { }

        /*
        public async Task<List<Artists>> GetArtists()
        {
            return await Context.Artists
                    .OrderBy(x => x.ArtistName)
                    .ToListAsync();

        }
        */

        public async Task<List<Artist>> GetArtists()
        {
            var result =  await Context.Artists
                    .OrderBy(x => x.ArtistName)
                    .ToListAsync();


            return Mapper.Map<List<Artists>,List<Artist>>(result);
            

        }
       
    }

}
