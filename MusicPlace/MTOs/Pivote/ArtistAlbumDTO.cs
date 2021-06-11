using MusicPlace.Models.Pivote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs.Pivote
{
    public class ArtistAlbumDTO : ArtistAlbum
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
    }
}
