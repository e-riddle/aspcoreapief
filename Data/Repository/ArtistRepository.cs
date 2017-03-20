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


        public async Task<List<Artist>> GetArtists(int page = 1, int pageSize = 15)
        {
            var artists =  Context.Artists
                            .OrderBy(x => x.ArtistName)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            ;
            

            return Mapper.Map<List<Artists>,List<Artist>>(await artists.ToListAsync());
            

        }


         public async Task<List<Artist>> GetArtist(int id)
        {
            var artists =  Context.Artists
                            .Include(x => x.Albums)
                            .Where(x => x.Id == id)
                            ;
            

            return Mapper.Map<List<Artists>,List<Artist>>(await artists.ToListAsync());
            

        }

       
    }

}
