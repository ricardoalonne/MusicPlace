using MusicPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class ArtistDTO : Artist
    {
        public List<Album> Albums { get; set; }
    }
}
