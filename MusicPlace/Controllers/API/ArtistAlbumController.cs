using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using MusicPlace.MTOs;
using MusicPlace.MTOs.Pivote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistAlbumController : ControllerBase
    {

        private MusicPlaceDBConnection connection;

        [HttpPost]
        public async Task<ArtistAlbumDTO> Post(ArtistAlbumDTO artistAlbum)
        {
            try
            {
                connection = new();
                return await connection.PostArtistAlbum(artistAlbum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<ArtistAlbumDTO> Put(int id, ArtistAlbumDTO artistAlbum)
        {
            try
            {
                connection = new();
                return await connection.PutArtistAlbum(id, artistAlbum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                connection = new();
                return await connection.DeleteArtistAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet]
        public async Task<List<ArtistAlbumDTO>> Get()
        {
            try
            {
                connection = new();
                return await connection.GetArtistAlbumsActive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all")]
        public async Task<List<ArtistAlbumDTO>> GetAll()
        {
            try
            {
                connection = new();
                return await connection.GetAllArtistAlbums();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<ArtistAlbumDTO> GetById(int id)
        {
            try
            {
                connection = new();
                return await connection.GetByIdArtistAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("Album/{id}")]
        public async Task<ArtistAlbumDTO> GetByIdAlbum(int id)
        {
            try
            {
                connection = new();
                return await connection.GetArtistAlbumByIdAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("Artist/all")]
        public async Task<List<AlbumsArtistDTO>> GetAlbumsAllArtist()
        {
            try
            {
                connection = new();
                return await connection.GetAlbumsAllArtist();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all/Artist/all")]
        public async Task<List<AlbumsArtistDTO>> GetAllAlbumsAllArtist()
        {
            try
            {
                connection = new();
                return await connection.GetAllAlbumsAllArtist();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("Artist/all/{id}")]
        public async Task<List<AlbumsArtistDTO>> GetAlbumsByArtist(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAlbumsByArtist(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all/Artist/all/{id}")]
        public async Task<List<AlbumsArtistDTO>> GetAllAlbumsByArtist(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAllAlbumsByArtist(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        [HttpGet("Album/all/{id}")]
        public async Task<List<Album>> GetAlbumByArtist(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAlbumByArtist(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all/Album/all/{id}")]
        public async Task<List<Album>> GetAllAlbumByArtist(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAllAlbumByArtist(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("full/Artist")]
        public async Task<List<ArtistFullDTO>> GetAlbumsArtistFull()
        {
            try
            {
                connection = new();
                return await connection.GetAlbumsArtistFull();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("full/all/Artist")]
        public async Task<List<ArtistFullDTO>> GetAllAlbumsArtistFull()
        {
            try
            {
                connection = new();
                return await connection.GetAllAlbumsArtistFull();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
