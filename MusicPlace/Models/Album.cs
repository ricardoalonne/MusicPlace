using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre", ShortName = "Nombre", Description = "Nombre del Album")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripción", ShortName = "Descripción", Description = "Descripción del Album")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Año", ShortName = "Año", Description = "Año del Album")]
        public string Year { get; set; }

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

        public static List<SelectListItem> ToSelectListItems(List<Album> albums, int id = -1)
        {
            List<SelectListItem> listAlbums = new();

            foreach (var album in albums)
            {
                listAlbums.Add(album.ToSelectListItem(id));
            }

            return listAlbums;
        }
    }
}
