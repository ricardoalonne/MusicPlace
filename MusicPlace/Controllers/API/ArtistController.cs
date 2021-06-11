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
    public class ArtistController : ControllerBase
    {

        private MusicPlaceDBConnection connection;

        [HttpPost]
        public async Task<Artist> Post(Artist artist)
        {
            try
            {
                connection = new();
                return await connection.PostArtist(artist);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<Artist> Put(int id, Artist artist)
        {
            try
            {
                connection = new();
                return await connection.PutArtist(id, artist);
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
                return await connection.DeleteArtist(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet]
        public async Task<List<Artist>> Get()
        {
            try
            {
                connection = new();
                return await connection.GetArtistsActive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all")]
        public async Task<List<Artist>> GetAll()
        {
            try
            {
                connection = new();
                return await connection.GetAllArtists();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<Artist> GetById(int id)
        {
            try
            {
                connection = new();
                return await connection.GetByIdArtist(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
