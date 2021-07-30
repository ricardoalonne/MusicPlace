using MusicPlace.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class SongDTO : Song
    {
        [Required]
        [Display(Name = "Album", ShortName = "Album", Description = "Album de la Canción")]
        public int IdAlbum { get; set; }

        public SongDTO ToDTO(Song song)
        {
            return new()
            {
                Id = song.Id,
                Name = song.Name,
                Duration = song.Duration,
                Active = song.Active
            };
        }

        public Song ToEntity(SongDTO songDTO)
        {
            return new()
            {
                Id = songDTO.Id,
                Name = songDTO.Name,
                Duration = songDTO.Duration,
                Active = songDTO.Active
            };
        }
    }
}
