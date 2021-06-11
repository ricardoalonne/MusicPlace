using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlace.Data
{
    public record MusicPlaceApiConnection
    {
        public MusicPlaceApiConnection(string RootPath = "https://localhost:44398/")
        {
            this.BaseUrl = RootPath;

            this.Album = this.BaseUrl + "/API/Album";
            this.Artist = this.BaseUrl + "/API/Artist";
            this.Song = this.BaseUrl + "/API/Song";
            this.User = this.BaseUrl + "/API/User";
            this.Client = this.BaseUrl + "/API/Client";

            this.AlbumSong = this.BaseUrl + "/API/AlbumSong";
            this.ArtistAlbum = this.BaseUrl + "/API/ArtistAlbum";
        }

        public string BaseUrl { get; }
        public string Album { get; }
        public string Artist { get; }
        public string Song { get; }
        public string User { get; }
        public string Client { get; }
        public string AlbumSong { get; }
        public string ArtistAlbum { get; }


        public string AlbumsAllArtistActive() { return ArtistAlbum + "/Artist/all"; }
        public string AlbumsAllArtist() { return ArtistAlbum + "/all/Artist/all"; }
        public string AlbumsByArtistActive() { return ArtistAlbum + "/Album/all/"; }
        public string AlbumsByArtist() { return ArtistAlbum + "/all/Album/all/"; }

        public string ArtistFull() { return ArtistAlbum + "/full/Artist"; }
        public string AllArtistFull() { return ArtistAlbum + "/full/all/Artist"; }

        public string SongsAllAlbumActive() { return AlbumSong + "/Album/all/"; }
        public string SongsAllAlbum() { return AlbumSong + "/all/Album/all/"; }
        public string SongsByAlbumActive() { return AlbumSong + "/Songs/all/"; }
        public string SongsByAlbum() { return AlbumSong + "/all/Songs/all/"; }
    }
}
