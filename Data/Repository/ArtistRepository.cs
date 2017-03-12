using System;
using System.Collections.Generic;
using System.Text;
using aspnetapp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace aspnetapp.Data.Repository
{
    public class ArtistRepository : EfRepositoryBase<AlbumsContext, Artists>
    {
        public ArtistRepository(AlbumsContext context)
            : base(context)
        { }

        public async Task<List<Artists>> GetArtists()
        {
            return await Context.Artists
                    .OrderBy(x => x.ArtistName)
                    .ToListAsync();

        }

       
    }

}
