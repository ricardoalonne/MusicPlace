using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Correo Electrónico", ShortName = "Email", Description = "Correo electrónico del Cliente")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña", ShortName = "Contraseña", Description = "Contraseña del Cliente")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario", ShortName = "Usuario", Description = "Nombre de usuario del Cliente")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Nombres", ShortName = "Nombres", Description = "Nombres del Cliente")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos", ShortName = "Apellidos", Description = "Apellidos del Cliente")]
        public string Lastname { get; set; }

        public bool Active { get; set; }
    }
}
