using System;
using System.Collections.Generic;

namespace aspnetapp.Data.Models
{
    public partial class Tracks
    {
        public int Id { get; set; }
        public int? AlbumId { get; set; }
        public string SongName { get; set; }
        public string Length { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Albums Album { get; set; }
    }
}
