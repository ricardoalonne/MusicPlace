using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicPlace.Models;
using MusicPlace.Models.Pivote;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Models.Album> Album { get; set; }
        public DbSet<Song> Song { get; set; }

        /*PIVOTE*/
        public DbSet<AlbumSong> AlbumSong { get; set; }
        public DbSet<Models.Pivote.ArtistAlbum> ArtistAlbum { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    RolesSystem(builder);
        //    //StoredProcedures(builder);
        //    base.OnModelCreating(builder);
        //}

        //private void RolesSystem(ModelBuilder builder)
        //{
        //    var hasher = new PasswordHasher<IdentityUser>();

        //    var OWNER = new IdentityUser()
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Email = "ricardo.ar.one.27@gmail.com",
        //        NormalizedEmail = "ricardo.ar.one.27@gmail.com".ToUpper(),
        //        UserName = "@ricardoarbildo",
        //        NormalizedUserName = "@ricardoarbildo".ToUpper(),
        //        EmailConfirmed = true,
        //        PhoneNumber = "+51 979 384 183",
        //        PhoneNumberConfirmed = true,
        //        PasswordHash = hasher.HashPassword(null, "RickElMasRick#27")

        //    };

        //    var RoleADMIN = new IdentityRole()
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "Admin",
        //        NormalizedName = "Admin".ToUpperInvariant()
        //    };

        //    var RoleUSER = new IdentityRole()
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Name = "User",
        //        NormalizedName = "User".ToUpperInvariant()
        //    };

        //    var RoleFREE = new IdentityRole()
        //    {

        //        Id = Guid.NewGuid().ToString(),
        //        Name = "Free",
        //        NormalizedName = "Free".ToUpperInvariant()

        //    };

        //    var RolePREMIUM = new IdentityRole()
        //    {

        //        Id = Guid.NewGuid().ToString(),
        //        Name = "Premium",
        //        NormalizedName = "Premium".ToUpperInvariant()
        //    };

        //    var DEVELOPER = new IdentityUserRole<string>()
        //    {
        //        RoleId = OWNER.Id,
        //        UserId = RoleADMIN.Id
        //    };

        //    builder.Entity<IdentityUser>().HasData(OWNER);
        //    builder.Entity<IdentityRole>().HasData(RoleADMIN);
        //    builder.Entity<IdentityRole>().HasData(RoleUSER);
        //    builder.Entity<IdentityRole>().HasData(RoleFREE);
        //    builder.Entity<IdentityRole>().HasData(RolePREMIUM);

        //    builder.Entity<IdentityUserRole<string>>().HasData(DEVELOPER);

        //}
    }
}
