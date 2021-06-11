using MusicPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs.Pivote
{
    public class AlbumFullDTO : Album
    {
        public List<Song> Songs { get; set; } 
    }
}
