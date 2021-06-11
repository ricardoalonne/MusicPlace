using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Models.Pivote
{
    public class AlbumSong
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Album", ShortName = "Album", Description = "Album")]
        public Album Album { get; set; }

        [Display(Name = "Cancion", ShortName = "Cancion", Description = "Cancion del Album")]
        public Song Song { get; set; }

        public bool Active { get; set; }
    }
}
