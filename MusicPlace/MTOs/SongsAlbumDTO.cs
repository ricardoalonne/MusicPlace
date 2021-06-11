using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class SongsAlbumDTO
    {
        public int Id { get; set; }
        public string Album { get; set; }
        public string Song { get; set; }
        public string Duration { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
    }
}
