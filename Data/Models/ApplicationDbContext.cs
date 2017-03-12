using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspnetapp.Data.Models
{
    public partial class AlbumsContext
    {
        public AlbumsContext(DbContextOptions<AlbumsContext> options) : base(options)
        {
                
        }
    }
}