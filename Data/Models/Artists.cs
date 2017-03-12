using System;
using System.Collections.Generic;

namespace aspnetapp.Data.Models
{
    public partial class Artists
    {
        public Artists()
        {
            Albums = new HashSet<Albums>();
        }

        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string AmazonUrl { get; set; }

        public virtual ICollection<Albums> Albums { get; set; }
    }
}
