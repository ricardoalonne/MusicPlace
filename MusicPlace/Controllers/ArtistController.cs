﻿using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using MyLoginWhitJWT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Controllers
{
    public class ArtistController : Controller
    {

        MusicPlaceApiConnection urlAPI;

        public async Task<IActionResult> Index()
        {
            ViewBag.Encabezado = "Artistas";
            ViewData["Title"] = "Artistas";
            ViewBag.ArtistPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var list = await HttpRequestsDirect.GetAll<Artist>(urlAPI.Artist, token);

            return View(list);
        }
    }
}
