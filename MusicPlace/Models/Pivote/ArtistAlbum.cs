using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Models.Pivote
{
    public class ArtistAlbum
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Artista", ShortName = "Artista", Description = "Artista")]
        public Artist Artist { get; set; }

        [Display(Name = "Album", ShortName = "Album", Description = "Album del Artista")]
        public Album Album { get; set; }

        public bool Active { get; set; }
    }
}
