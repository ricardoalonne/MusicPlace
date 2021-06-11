using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre", ShortName = "Nombre", Description = "Nombre de la Canción")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Duración", ShortName = "Duración", Description = "Duración de la Canción")]
        public string Duration { get; set; }

        public bool Active { get; set; }




        public SelectListItem ToSelectListItem(int id = -1)
        {
            if (this.Id == id)
                return new()
                {
                    Selected = true,
                    Text = this.Name,
                    Value = this.Id.ToString()
                };

            return new()
            {
                Text = this.Name,
                Value = this.Id.ToString()
            };
        }

        public static List<SelectListItem> ToSelectListItems(List<Song> songs, int id = -1)
        {
            List<SelectListItem> listSongs = new();

            foreach (var song in songs)
            {
                listSongs.Add(song.ToSelectListItem(id));
            }

            return listSongs;
        }
    }
}

//Add Genere