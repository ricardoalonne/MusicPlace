using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.MTOs;
using MyLoginWhitJWT.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Controllers
{
    public class GeneralController : Controller
    {
        MusicPlaceApiConnection urlAPI;

        public async Task<IActionResult> Index()
        {
            ViewBag.Encabezado = "General";
            ViewData["Title"] = "General";
            ViewBag.GeneralPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var all = await HttpRequestsDirect.GetAll<ArtistFullDTO>(urlAPI.ArtistFull(), token);

            return View(all);
        }
    }
}
