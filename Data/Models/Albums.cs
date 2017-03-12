using System;
using System.Collections.Generic;

namespace aspnetapp.Data.Models
{
    public partial class Albums
    {
        public Albums()
        {
            Tracks = new HashSet<Tracks>();
        }

        public int Id { get; set; }
        public int? ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string AmazonUrl { get; set; }
        public string SpotifyUrl { get; set; }

        public virtual ICollection<Tracks> Tracks { get; set; }
        public virtual Artists Artist { get; set; }
    }
}
