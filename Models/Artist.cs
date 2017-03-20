using System.Collections.Generic;

namespace aspnetapp.Models
{
    
    public class Artist
    {
         /// <summary>
        /// The id of the artist.
        /// </summary>
        public int Id { get; set; }

         /// <summary>
        /// The name of the artist.
        /// </summary>
        public string ArtistName { get; set; }

         /// <summary>
        /// The description of the artist.
        /// </summary>
        public string Description { get; set; }

         /// <summary>
        /// The image location.
        /// </summary>
        public string ImageUrl { get; set; }

         /// <summary>
        /// The amazon location.
        /// </summary>
        public string AmazonUrl { get; set; }

        ///A list of albums
        public List<Album> Albums {get;set;} = new List<Album>();

        

    }

     public  class Album
    {
       
        public int Id { get; set; }
        public int? ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string AmazonUrl { get; set; }
        public string SpotifyUrl { get; set; }

    }

}