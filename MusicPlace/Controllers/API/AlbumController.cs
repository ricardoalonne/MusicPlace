using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private MusicPlaceDBConnection connection;

        [HttpPost]
        public async Task<Album> Post(Album album)
        {
            try
            {
                connection = new();
                return await connection.PostAlbum(album);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<Album> Put(int id, Album album)
        {
            try
            {
                connection = new();
                return await connection.PutAlbum(id, album);
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
                return await connection.DeleteAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet]
        public async Task<List<Album>> Get()
        {
            try
            {
                connection = new();
                return await connection.GetAlbumsActive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all")]
        public async Task<List<Album>> GetAll()
        {
            try
            {
                connection = new();
                return await connection.GetAllAlbums();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<Album> GetById(int id)
        {
            try
            {
                connection = new();
                return await connection.GetByIdAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
