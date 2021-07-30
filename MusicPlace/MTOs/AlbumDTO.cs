using MusicPlace.Models;
using MusicPlace.Models.Pivote;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.MTOs
{
    public class AlbumDTO : Album
    {
        public List<Song> Songs { get; set; }

        [Required]
        [Display(Name = "Artista", ShortName = "Artista", Description = "Artista del Album")]
        public int IdArtist { get; set; }

        public AlbumDTO ToDTO(Album album)
        {
            return new()
            {
                Id = album.Id,
                Name = album.Name,
                Year = album.Year,
                Description = album.Description,
                Active = album.Active
            };
        }

        public Album ToEntity(AlbumDTO albumDTO)
        {
            return new()
            {
                Id = albumDTO.Id,
                Name = albumDTO.Name,
                Year = albumDTO.Year,
                Description = albumDTO.Description,
                Active = albumDTO.Active
            };
        }
    }
}
