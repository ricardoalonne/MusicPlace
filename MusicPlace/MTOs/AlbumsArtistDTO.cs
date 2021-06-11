using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class AlbumsArtistDTO
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}
