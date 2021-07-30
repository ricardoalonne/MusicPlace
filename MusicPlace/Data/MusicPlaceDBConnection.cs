using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebPEIN;
using MusicPlace.Models;
using MusicPlace.Models.Pivote;
using MusicPlace.MTOs;
using MusicPlace.MTOs.Pivote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Data
{
    public class MusicPlaceDBConnection
    {
        private readonly string conn;
        public MusicPlaceDBConnection() =>  conn = GetConfiguration().GetConnectionString("DefaultConnection");
        
        public IConfigurationRoot GetConfiguration()
        {
            var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return build.Build();
        }

        #region Song
        internal async Task<bool> DeleteSong(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<Song>("Delete__Song", conn, parametros);
        }

        internal async Task<List<Song>> GetSongsActive()
        {
            return await GenericStoreProcedure.GetAll<Song>("Get__Songs", conn);
        }

        internal async Task<List<Song>> GetAllSongs()
        {
            return await GenericStoreProcedure.GetAll<Song>("GetAll__Songs", conn);
        }

        internal async Task<Song> GetByIdSong(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.GetByParameters<Song>("GetById__Song", conn, parametros);
        }

        internal async Task<Song> PostSong(Song song)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@name", song.Name);
            parametros[1] = new SqlParameter("@duration", song.Duration);

            return await GenericStoreProcedure.SendAndGetData<Song>("Post__Song", conn, parametros);
        }

        internal async Task<Song> PutSong(int id, Song song)
        {
            if (id != song.Id) return null;

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@name", song.Name);
            parametros[2] = new SqlParameter("@duration", song.Duration);

            return await GenericStoreProcedure.SendAndGetData<Song>("Put__Song", conn, parametros);
        }
        #endregion

        #region Album
        internal async Task<bool> DeleteAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<Album>("Delete__Album", conn, parametros);
        }

        internal async Task<List<Album>> GetAlbumsActive()
        {
            return await GenericStoreProcedure.GetAll<Album>("Get__Albums", conn);
        }

        internal async Task<List<Album>> GetAllAlbums()
        {
            return await GenericStoreProcedure.GetAll<Album>("GetAll__Albums", conn);
        }

        internal async Task<Album> GetByIdAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.GetByParameters<Album>("GetById__Album", conn, parametros);
        }

        internal async Task<Album> PostAlbum(Album album)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@name", album.Name);
            parametros[1] = new SqlParameter("@descripcion", album.Description);
            parametros[2] = new SqlParameter("@year", album.Year);

            return await GenericStoreProcedure.SendAndGetData<Album>("Post__Album", conn, parametros);
        }

        internal async Task<Album> PutAlbum(int id, Album album)
        {
            if (id != album.Id) return null;

            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@name", album.Name);
            parametros[2] = new SqlParameter("@descripcion", album.Description);
            parametros[3] = new SqlParameter("@year", album.Year);

            return await GenericStoreProcedure.SendAndGetData<Album>("Put__Album", conn, parametros);
        }

        #endregion

        #region Artist
        internal async Task<bool> DeleteArtist(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<Artist>("Delete__Artist", conn, parametros);
        }

        internal async Task<List<Artist>> GetArtistsActive()
        {
            return await GenericStoreProcedure.GetAll<Artist>("Get__Artists", conn);
        }

        internal async Task<List<Artist>> GetAllArtists()
        {
            return await GenericStoreProcedure.GetAll<Artist>("GetAll__Artists", conn);
        }

        internal async Task<Artist> GetByIdArtist(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.GetByParameters<Artist>("GetById__Artist", conn, parametros);
        }

        internal async Task<Artist> PostArtist(Artist artist)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@name", artist.Name);

            return await GenericStoreProcedure.SendAndGetData<Artist>("Post__Artist", conn, parametros);
        }

        internal async Task<Artist> PutArtist(int id, Artist artist)
        {
            if (id != artist.Id) return null;

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@name", artist.Name);

            return await GenericStoreProcedure.SendAndGetData<Artist>("Put__Artist", conn, parametros);
        }

        #endregion

        #region User
        internal async Task<bool> DeleteUser(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<User>("Delete__User", conn, parametros);
        }

        internal async Task<List<User>> GetUsersActive()
        {
            return await GenericStoreProcedure.GetAll<User>("Get__Users", conn);
        }

        internal async Task<List<User>> GetAllUsers()
        {
            return await GenericStoreProcedure.GetAll<User>("GetAll__Users", conn);
        }

        internal async Task<User> GetByIdUser(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.GetByParameters<User>("GetById__User", conn, parametros);
        }

        internal async Task<User> PostUser(User user)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@email", user.Email);
            parametros[1] = new SqlParameter("@password", user.Password);
            parametros[2] = new SqlParameter("@username", user.Username);
            parametros[3] = new SqlParameter("@role", user.Role);
            parametros[4] = new SqlParameter("@name", user.Name);
            parametros[5] = new SqlParameter("@lastname", user.Lastname);

            return await GenericStoreProcedure.SendAndGetData<User>("Post__User", conn, parametros);
        }

        internal async Task<User> PutUser(int id, User user)
        {
            if (id != user.Id) return null;

            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@email", user.Email);
            parametros[2] = new SqlParameter("@password", user.Password);
            parametros[3] = new SqlParameter("@username", user.Username);
            parametros[4] = new SqlParameter("@role", user.Role);
            parametros[5] = new SqlParameter("@name", user.Name);
            parametros[6] = new SqlParameter("@lastname", user.Lastname);

            return await GenericStoreProcedure.SendAndGetData<User>("Put__User", conn, parametros);
        }

        #endregion

        #region Client
        internal async Task<bool> DeleteClient(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<Client>("Delete__Client", conn, parametros);
        }

        internal async Task<List<Client>> GetClientsActive()
        {
            return await GenericStoreProcedure.GetAll<Client>("Get__Clients", conn);
        }

        internal async Task<List<Client>> GetAllClients()
        {
            return await GenericStoreProcedure.GetAll<Client>("GetAll__Clients", conn);
        }

        internal async Task<Client> GetByIdClient(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.GetByParameters<Client>("GetById__Client", conn, parametros);
        }

        internal async Task<Client> PostClient(Client client)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@email", client.Email);
            parametros[1] = new SqlParameter("@password", client.Password);
            parametros[2] = new SqlParameter("@username", client.Username);
            parametros[3] = new SqlParameter("@name", client.Name);
            parametros[4] = new SqlParameter("@lastname", client.Lastname);

            return await GenericStoreProcedure.SendAndGetData<Client>("Post__Client", conn, parametros);
        }

        internal async Task<Client> PutClient(int id, Client client)
        {
            if (id != client.Id) return null;

            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@email", client.Email);
            parametros[2] = new SqlParameter("@password", client.Password);
            parametros[3] = new SqlParameter("@username", client.Username);
            parametros[4] = new SqlParameter("@name", client.Name);
            parametros[5] = new SqlParameter("@lastname", client.Lastname);

            return await GenericStoreProcedure.SendAndGetData<Client>("Put__Client", conn, parametros);
        }

        #endregion

        #region ArtistAlbums
        internal async Task<bool> DeleteArtistAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<ArtistAlbum>("Delete__ArtistAlbum", conn, parametros);
        }

        internal async Task<List<ArtistAlbumDTO>> GetArtistAlbumsActive()
        {
            var listAlbums = await GenericStoreProcedure.GetAll<ArtistAlbumDTO>("Get__ArtistAlbums", conn);

            foreach(var album in listAlbums)
            {
                album.Artist = await GetByIdArtist(album.ArtistId);
                album.Album = await GetByIdAlbum(album.AlbumId);
            }

            return listAlbums;
        }

        internal async Task<List<ArtistAlbumDTO>> GetAllArtistAlbums()
        {
            var listAlbums = await GenericStoreProcedure.GetAll<ArtistAlbumDTO>("GetAll__ArtistAlbums", conn);

            foreach (var album in listAlbums)
            {
                album.Artist = await GetByIdArtist(album.ArtistId);
                album.Album = await GetByIdAlbum(album.AlbumId);
            }

            return listAlbums;
        }

        internal async Task<ArtistAlbumDTO> GetByIdArtistAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            var album = await GenericStoreProcedure.GetByParameters<ArtistAlbumDTO>("GetById__ArtistAlbum", conn, parametros);

            album.Artist = await GetByIdArtist(album.ArtistId);
            album.Album = await GetByIdAlbum(album.AlbumId);

            return album;
        }

        internal async Task<ArtistAlbumDTO> GetArtistAlbumByIdAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            var album = await GenericStoreProcedure.GetByParameters<ArtistAlbumDTO>("GetById__ArtistAlbum_ByIdAlbum", conn, parametros);

            album.Artist = await GetByIdArtist(album.ArtistId);
            album.Album = await GetByIdAlbum(album.AlbumId);

            return album;
        }

        internal async Task<List<AlbumsArtistDTO>> GetAlbumsAllArtist()
        {
            return await GenericStoreProcedure.GetAll<AlbumsArtistDTO>("Get__Albums_AllArtist", conn);
        }

        internal async Task<List<AlbumsArtistDTO>> GetAllAlbumsAllArtist()
        {

            return await GenericStoreProcedure.GetAll<AlbumsArtistDTO>("GetAll__Albums_AllArtist", conn);
        }

        internal async Task<List<AlbumsArtistDTO>> GetAlbumsByArtist(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@artistId", id);

            return await GenericStoreProcedure.GetAllByParameter<AlbumsArtistDTO>("Get__Albums_ByArtist", conn, parametros);
        }

        internal async Task<List<AlbumsArtistDTO>> GetAllAlbumsByArtist(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@artistId", id);

            return await GenericStoreProcedure.GetAllByParameter<AlbumsArtistDTO>("GetAll__Albums_ByArtist", conn, parametros);
        }

        internal async Task<List<Album>> GetAlbumByArtist(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@artistId", id);

            return await GenericStoreProcedure.GetAllByParameter<Album>("Get__Album_ByArtist", conn, parametros);
        }

        internal async Task<List<Album>> GetAllAlbumByArtist(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@artistId", id);

            return await GenericStoreProcedure.GetAllByParameter<Album>("GetAll__Album_ByArtist", conn, parametros);
        }


        internal async Task<List<ArtistFullDTO>> GetAlbumsArtistFull()
        {
            List<ArtistFullDTO> allArtist = new List<ArtistFullDTO>();
            var artists = await GetArtistsActive();

            foreach (var artist in artists)
            {
                ArtistFullDTO artistFull = new()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Active = artist.Active,
                    Albums = new()
                };
                var albums = await GetAlbumByArtist(artistFull.Id);
                foreach (var album in albums)
                {
                    AlbumFullDTO albumFull = new()
                    {
                        Id = album.Id,
                        Name = album.Name,
                        Description = album.Description,
                        Year = album.Year,
                        Active = album.Active,
                        Songs = await GetSongByAlbum(album.Id)
                    };
                    artistFull.Albums.Add(albumFull);
                }
                allArtist.Add(artistFull);
            }

            return allArtist;
        }

        internal async Task<List<ArtistFullDTO>> GetAllAlbumsArtistFull()
        {
            List<ArtistFullDTO> allArtist = new List<ArtistFullDTO>();
            var artists = await GetAllArtists();


            foreach (var artist in artists)
            {
                ArtistFullDTO artistFull = new()
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Active = artist.Active,
                    Albums = new()
                };
                var albums = await GetAllAlbumByArtist(artistFull.Id);
                foreach (var album in albums)
                {
                    AlbumFullDTO albumFull = new()
                    {
                        Id = album.Id,
                        Name = album.Name,
                        Description = album.Description,
                        Year = album.Year,
                        Active = album.Active,
                        Songs = await GetAllSongByAlbum(album.Id)
                    };
                    artistFull.Albums.Add(albumFull);
                }
                allArtist.Add(artistFull);
            }
            
            return allArtist;
        }

        internal async Task<ArtistAlbumDTO> PostArtistAlbum(ArtistAlbumDTO album)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@albumId", album.AlbumId);
            parametros[1] = new SqlParameter("@artistId", album.ArtistId);

            var result = await GenericStoreProcedure.SendAndGetData<ArtistAlbumDTO>("Post__ArtistAlbum", conn, parametros);
            result.Artist = await GetByIdArtist(album.ArtistId);
            result.Album = await GetByIdAlbum(album.AlbumId);

            return result;
        }

        internal async Task<ArtistAlbumDTO> PutArtistAlbum(int id, ArtistAlbumDTO album)
        {
            if (id != album.Id) return null;

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@albumId", album.AlbumId);
            parametros[2] = new SqlParameter("@artistId", album.ArtistId);

            var result = await GenericStoreProcedure.SendAndGetData<ArtistAlbumDTO>("Put__ArtistAlbum", conn, parametros);
            result.Artist = await GetByIdArtist(album.ArtistId);
            result.Album = await GetByIdAlbum(album.AlbumId);

            return result;
        }

        #endregion

        #region AlbumSongs
        internal async Task<bool> DeleteAlbumSong(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            return await GenericStoreProcedure.ProcedureBoolean<AlbumSong>("Delete__AlbumSong", conn, parametros);
        }

        internal async Task<List<AlbumSongDTO>> GetAlbumSongsActive()
        {
            var listAlbums = await GenericStoreProcedure.GetAll<AlbumSongDTO>("Get__AlbumSongs", conn);

            foreach (var album in listAlbums)
            {
                album.Album = await GetByIdAlbum(album.AlbumId);
                album.Song = await GetByIdSong(album.SongId);
            }

            return listAlbums;
        }

        internal async Task<List<AlbumSongDTO>> GetAllAlbumSongs()
        {

            var listAlbums = await GenericStoreProcedure.GetAll<AlbumSongDTO>("GetAll__AlbumSongs", conn);

            foreach (var album in listAlbums)
            {
                album.Album = await GetByIdAlbum(album.AlbumId);
                album.Song = await GetByIdSong(album.SongId);
            }

            return listAlbums;
        }

        internal async Task<AlbumSongDTO> GetByIdAlbumSong(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            var album = await GenericStoreProcedure.GetByParameters<AlbumSongDTO>("GetById__AlbumSong", conn, parametros);

            album.Album = await GetByIdAlbum(album.AlbumId);
            album.Song = await GetByIdSong(album.SongId);

            return album;
        }

        internal async Task<AlbumSongDTO> GetAlbumSongByIdSong(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);

            var album = await GenericStoreProcedure.GetByParameters<AlbumSongDTO>("GetById__AlbumSong_ByIdSong", conn, parametros);

            album.Album = await GetByIdAlbum(album.AlbumId);
            album.Song = await GetByIdSong(album.SongId);

            return album;
        }


        internal async Task<List<SongsAlbumDTO>> GetSongsAllAlbum()
        {
            return await GenericStoreProcedure.GetAll<SongsAlbumDTO>("Get__Songs_AllAlbum", conn);
        }

        internal async Task<List<SongsAlbumDTO>> GetAllSongsAllAlbum()
        {

            return await GenericStoreProcedure.GetAll<SongsAlbumDTO>("GetAll__Songs_AllAlbum", conn);
        }

        internal async Task<List<SongsAlbumDTO>> GetSongsByAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@albumId", id);

            return await GenericStoreProcedure.GetAllByParameter<SongsAlbumDTO>("Get__Songs_ByAlbum", conn, parametros);
        }

        internal async Task<List<SongsAlbumDTO>> GetAllSongsByAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@albumId", id);

            return await GenericStoreProcedure.GetAllByParameter<SongsAlbumDTO>("GetAll__Songs_ByAlbum", conn, parametros);
        }

        internal async Task<List<Song>> GetSongByAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@albumId", id);

            //return await GenericStoreProcedure.GetAllByParameter<Song>("Get__Song_ByAlbum", conn, parametros);
            var temp = await GenericStoreProcedure.GetAllByParameter<Song>("Get__Song_ByAlbum", conn, parametros);
            return temp;
        }

        internal async Task<List<Song>> GetAllSongByAlbum(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@albumId", id);

            return await GenericStoreProcedure.GetAllByParameter<Song>("GetAll__Song_ByAlbum", conn, parametros);
        }


        internal async Task<AlbumSongDTO> PostAlbumSong(AlbumSongDTO song)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@songId", song.SongId);
            parametros[1] = new SqlParameter("@albumId", song.AlbumId);

            var result = await GenericStoreProcedure.SendAndGetData<AlbumSongDTO>("Post__AlbumSong", conn, parametros);
            result.Album = await GetByIdAlbum(song.AlbumId);
            result.Song = await GetByIdSong(song.SongId);

            return result;
        }

        internal async Task<AlbumSongDTO> PutAlbumSong(int id, AlbumSongDTO song)
        {
            if (id != song.Id) return null;

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@id", id);
            parametros[1] = new SqlParameter("@songId", song.SongId);
            parametros[2] = new SqlParameter("@albumId", song.AlbumId);

            var result = await GenericStoreProcedure.SendAndGetData<AlbumSongDTO>("Put__AlbumSong", conn, parametros);
            result.Album = await GetByIdAlbum(song.AlbumId);
            result.Song = await GetByIdSong(song.SongId);

            return result;
        }
        #endregion
    }
}
