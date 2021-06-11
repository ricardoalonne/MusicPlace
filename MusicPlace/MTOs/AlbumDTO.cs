using MusicPlace.Models;
using MusicPlace.Models.Pivote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class AlbumDTO : Album
    {
        public List<Song> Songs { get; set; }
    }
}
