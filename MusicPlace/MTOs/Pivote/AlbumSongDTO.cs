using MusicPlace.Models.Pivote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs.Pivote
{
    public class AlbumSongDTO : AlbumSong
    {
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }
}
