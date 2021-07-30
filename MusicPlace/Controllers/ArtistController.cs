using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using WebPEIN;
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

        public async Task<IActionResult> VerDetalle(int id)
        {
            ViewBag.Encabezado = "Artistas";
            ViewData["Title"] = "Ver detalles del Artista";
            ViewBag.ArtistPageActive = "active";

            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var artist = await HttpRequestsDirect.GetById<Artist>(id,urlAPI.Artist, token);

            return View(artist);
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            ViewBag.Encabezado = "Artistas";
            ViewBag.ArtistPageActive = "active";

            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            Artist artist = new();

            if (id == -1) artist = null;
            else artist = await HttpRequestsDirect.GetById<Artist>(id, urlAPI.Artist, token);

            return View(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(Artist artist)
        {
            ViewBag.Encabezado = "Artistas";
            ViewData["Title"] = "Artistas";
            ViewBag.ArtistPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            if(artist.Id == -1) artist = await HttpRequestsDirect.Post<Artist>(artist, urlAPI.Artist, token);
            else artist = await HttpRequestsDirect.Put<Artist>(artist, artist.Id, urlAPI.Artist, token);

            if (artist != null)
            {

            }

            var list = await HttpRequestsDirect.GetAll<Artist>(urlAPI.Artist, token);

            return View("Index", list);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            ViewBag.Encabezado = "Artistas";
            ViewData["Title"] = "Artistas";
            ViewBag.ArtistPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var result = await HttpRequestsDirect.Delete(id, urlAPI.Artist, token);

            if (result)
            {

            }

            var list = await HttpRequestsDirect.GetAll<Artist>(urlAPI.Artist, token);

            return View("Index", list);
        }
    }
}
