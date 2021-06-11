using MusicPlace.Models;
using MusicPlace.MTOs.Pivote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class ArtistFullDTO : Artist
    {
        public List<AlbumFullDTO> Albums { get; set; }
    }
}
