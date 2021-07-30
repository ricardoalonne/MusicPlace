using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPlace.Data;
using MusicPlace.Models;
using MusicPlace.Models.Pivote;
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
    public class AlbumSongController : ControllerBase
    {

        private MusicPlaceDBConnection connection;

        [HttpPost]
        public async Task<AlbumSongDTO> Post(AlbumSongDTO albumSongs)
        {
            try
            {
                connection = new();
                return await connection.PostAlbumSong(albumSongs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpPut("{id}")]
        public async Task<AlbumSongDTO> Put(int id, AlbumSongDTO albumSongs)
        {
            try
            {
                connection = new();
                return await connection.PutAlbumSong(id, albumSongs);
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
                return await connection.DeleteAlbumSong(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet]
        public async Task<List<AlbumSongDTO>> Get()
        {
            try
            {
                connection = new();
                return await connection.GetAlbumSongsActive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all")]
        public async Task<List<AlbumSongDTO>> GetAll()
        {
            try
            {
                connection = new();
                return await connection.GetAllAlbumSongs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<AlbumSongDTO> GetById(int id)
        {
            try
            {
                connection = new();
                return await connection.GetByIdAlbumSong(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("Song/{id}")]
        public async Task<AlbumSongDTO> GetByIdSong(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAlbumSongByIdSong(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("Albums/all")]
        public async Task<List<SongsAlbumDTO>> GetSongsByAllAlbum()
        {
            try
            {
                connection = new();
                return await connection.GetSongsAllAlbum();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all/Albums/all")]
        public async Task<List<SongsAlbumDTO>> GetAllSongsByAllAlbum()
        {
            try
            {
                connection = new();
                return await connection.GetAllSongsAllAlbum();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("Albums/all/{id}")]
        public async Task<List<SongsAlbumDTO>> GetSongsByAlbum(int id)
        {
            try
            {
                connection = new();
                return await connection.GetSongsByAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all/Albums/all/{id}")]
        public async Task<List<SongsAlbumDTO>> GetAllSongsByAlbum(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAllSongsByAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        [HttpGet("Songs/all/{id}")]
        public async Task<List<Song>> GetSongByAlbum(int id)
        {
            try
            {
                connection = new();
                return await connection.GetSongByAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet("all/Songs/all/{id}")]
        public async Task<List<Song>> GetAllSongByAlbum(int id)
        {
            try
            {
                connection = new();
                return await connection.GetAllSongByAlbum(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
