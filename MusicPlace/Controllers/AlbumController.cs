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
    public class AlbumController : Controller
    {
        MusicPlaceApiConnection urlAPI;

        public async Task<IActionResult> Index()
        {
            ViewBag.Encabezado = "Albunes";
            ViewData["Title"] = "Albunes";
            ViewBag.AlbumPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var list = await HttpRequestsDirect.GetAll<Album>(urlAPI.Album, token);

            return View(list);
        }

        
        public async Task<IActionResult> VerDetalle(int id)
        {
            ViewBag.Encabezado = "Albunes";
            ViewData["Title"] = "Ver detalles de Albun";
            ViewBag.AlbumPageActive = "active";

            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var album = await HttpRequestsDirect.GetById<Album>(id, urlAPI.Album, token);

            return View(album);
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            ViewBag.Encabezado = "Albunes";
            ViewBag.AlbumPageActive = "active";

            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            ViewBag.AllArtist = (Artist.ToSelectListItems(await HttpRequestsDirect.GetAll<Artist>(urlAPI.Artist, token)));

            AlbumDTO albumDTO;

            if (id == -1) albumDTO = null;
            else albumDTO = new AlbumDTO().ToDTO(await HttpRequestsDirect.GetById<Album>(id, urlAPI.Album, token));

            return View(albumDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(AlbumDTO albumDTO)
        {
            ViewBag.Encabezado = "Albunes";
            ViewData["Title"] = "Albunes";
            ViewBag.AlbumPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            Album album = albumDTO.ToEntity(albumDTO);

            if (album.Id == -1) album = await HttpRequestsDirect.Post<Album>(album, urlAPI.Album, token);
            else album = await HttpRequestsDirect.Put<Album>(album, album.Id, urlAPI.Album, token);

            if (album != null)
            {
                ArtistAlbumDTO artistAlbum = new()
                {
                    Id = -1,
                    AlbumId = album.Id,
                    ArtistId = albumDTO.IdArtist
                };
                if (albumDTO.Id == -1) artistAlbum = await HttpRequestsDirect.Post<ArtistAlbumDTO>(artistAlbum, urlAPI.ArtistAlbum, token);
                else 
                {
                    //Error al consultar a la api
                    //var olddata = await HttpRequestsDirect.GetById<ArtistAlbumDTO>(albumDTO.Id, urlAPI.AlbumArtistByIdAlbum(), token);
                    var olddata = await new MusicPlace.Data.MusicPlaceDBConnection().GetArtistAlbumByIdAlbum(albumDTO.Id);
                    artistAlbum.Id = olddata.Id;
                    artistAlbum = await HttpRequestsDirect.Put<ArtistAlbumDTO>(artistAlbum, olddata.Id, urlAPI.ArtistAlbum, token);
                }
                if (artistAlbum != null)
                {
                    
                }
            }

            var list = await HttpRequestsDirect.GetAll<Album>(urlAPI.Album, token);

            return View("Index", list);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            ViewBag.Encabezado = "Albunes";
            ViewData["Title"] = "Albunes";
            ViewBag.AlbumPageActive = "active";
            urlAPI = new($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var token = HttpContext.Request.Cookies["Token"];

            var result = await HttpRequestsDirect.Delete(id, urlAPI.Album, token);

            if (result)
            {

            }

            var list = await HttpRequestsDirect.GetAll<Album>(urlAPI.Album, token);

            return View("Index", list);
        }
    }
}
