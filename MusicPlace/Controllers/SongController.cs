using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using MusicPlace.MTOs;
using MusicPlace.MTOs.Pivote;
using WebPEIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Controllers
{
    public class SongController : Controller
    {
        MusicPlaceApiConnection urlAPI;

        public async Task<IActionResult> Index()
        {
            ViewBag.Encabezado = "Canciones";
            ViewData["Title"] = "Canciones";
            ViewBag.SongPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var list = await HttpRequestsDirect.GetAll<Song>(urlAPI.Song, token);

            return View(list);
        }

        public async Task<IActionResult> VerDetalle(int id)
        {
            ViewBag.Encabezado = "Canciones";
            ViewData["Title"] = "Ver detalles de Canciones";
            ViewBag.SongPageActive = "active";

            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var song = await HttpRequestsDirect.GetById<Song>(id, urlAPI.Song, token);

            return View(song);
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            ViewBag.Encabezado = "Canciones";
            ViewBag.SongPageActive = "active";

            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            ViewBag.AllAlbums = (Album.ToSelectListItems(await HttpRequestsDirect.GetAll<Album>(urlAPI.Album, token)));

            Song song = new();

            if (id == -1) song = null;
            else song = await HttpRequestsDirect.GetById<Song>(id, urlAPI.Song, token);

            return View(song);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(SongDTO songDTO)
        {
            ViewBag.Encabezado = "Canciones";
            ViewData["Title"] = "Canciones";
            ViewBag.SongPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            Song song = songDTO.ToEntity(songDTO);

            if (song.Id == -1) song = await HttpRequestsDirect.Post<Song>(song, urlAPI.Song, token);
            else song = await HttpRequestsDirect.Put<Song>(song, song.Id, urlAPI.Song, token);

            if (song != null)
            {
                AlbumSongDTO albumSong = new()
                {
                    Id = -1,
                    SongId = song.Id,
                    AlbumId = songDTO.IdAlbum
                };
                if (songDTO.Id == -1) albumSong = await HttpRequestsDirect.Post<AlbumSongDTO>(albumSong, urlAPI.AlbumSong, token);
                else 
                { 
                    var olddata = await HttpRequestsDirect.GetById<AlbumSongDTO>(songDTO.Id, urlAPI.SongAlbumByIdSong(), token);

                    albumSong = await HttpRequestsDirect.Put<AlbumSongDTO>(albumSong, olddata.Id, urlAPI.AlbumSong, token); 
                }
                if (albumSong != null)
                {

                }
            }

            var list = await HttpRequestsDirect.GetAll<Song>(urlAPI.Song, token);

            return View("Index", list);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            ViewBag.Encabezado = "Canciones";
            ViewData["Title"] = "Canciones";
            ViewBag.SongPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var result = await HttpRequestsDirect.Delete(id, urlAPI.Song, token);

            if (result)
            {

            }

            var list = await HttpRequestsDirect.GetAll<Song>(urlAPI.Song, token);

            return View("Index", list);
        }
    }
}
