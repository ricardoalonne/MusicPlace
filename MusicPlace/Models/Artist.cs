using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[MaxLength(50, ErrorMessage = "tamaño maximo 50 caracteres")]
        //[MinLength(1, ErrorMessage = "Minimo 1 Caracteres")]
        [Display(Name = "Nombre", ShortName = "Nm", Description = "Nombre del Artísta")]
        public string Name { get; set; }

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

        public static List<SelectListItem> ToSelectListItems(List<Artist> artists, int id = -1)
        {
            List<SelectListItem> listArtist = new();

            foreach (var artist in artists)
            {
                listArtist.Add(artist.ToSelectListItem(id));
            }

            return listArtist;
        }
    }
}
