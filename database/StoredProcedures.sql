/*DELETE*/

CREATE OR ALTER PROCEDURE [dbo].[Delete__Song]
	@id INT
AS
BEGIN
		UPDATE Song SET Active = 0 WHERE id = @id
		SELECT * FROM Song WHERE @id = id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Delete__Artist]
	@id INT
AS
BEGIN
		UPDATE Artist SET Active = 0 WHERE id = @id
		SELECT * FROM Artist WHERE @id = id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Delete__Album]
	@id INT
AS
BEGIN
		UPDATE Album SET Active = 0 WHERE id = @id
		SELECT * FROM Album WHERE @id = id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Delete__User]
	@id INT
AS
BEGIN
		UPDATE [User] SET Active = 0 WHERE id = @id
		SELECT * FROM [User] WHERE @id = id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Delete__Client]
	@id INT
AS
BEGIN
		UPDATE Client SET Active = 0 WHERE id = @id
		SELECT * FROM Client WHERE @id = id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Delete__AlbumSong]
	@id INT
AS
BEGIN
		UPDATE AlbumSong SET Active = 0 WHERE id = @id
		SELECT * FROM AlbumSong WHERE @id = id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Delete__ArtistAlbum]
	@id INT
AS
BEGIN
		UPDATE ArtistAlbum SET Active = 0 WHERE id = @id
		SELECT * FROM ArtistAlbum WHERE @id = id
END
GO


/*GET*/


CREATE OR ALTER PROCEDURE [dbo].[Get__Songs]
AS
BEGIN
		SELECT * FROM Song
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Songs]
AS
BEGIN
		SELECT * FROM Song
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__Song]
	@id int
AS
BEGIN
		SELECT * FROM Song
		WHERE id = @id
END
GO


CREATE OR ALTER PROCEDURE [dbo].[Get__Artists]
AS
BEGIN
		SELECT * FROM Artist
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Artists]
AS
BEGIN
		SELECT * FROM Artist
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__Artist]
	@id int
AS
BEGIN
		SELECT * FROM Artist
		WHERE id = @id
END
GO


CREATE OR ALTER PROCEDURE [dbo].[Get__Albums]
AS
BEGIN
		SELECT * FROM Album
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Albums]
AS
BEGIN
		SELECT * FROM Album
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__Album]
	@id int
AS
BEGIN
		SELECT * FROM Album
		WHERE id = @id
END
GO



CREATE OR ALTER PROCEDURE [dbo].[Get__Users]
AS
BEGIN
		SELECT * FROM [User]
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Users]
AS
BEGIN
		SELECT * FROM [User]
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__User]
	@id int
AS
BEGIN
		SELECT * FROM [User]
		WHERE id = @id
END
GO



CREATE OR ALTER PROCEDURE [dbo].[Get__Clients]
AS
BEGIN
		SELECT * FROM Client
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Clients]
AS
BEGIN
		SELECT * FROM Client
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__Client]
	@id int
AS
BEGIN
		SELECT * FROM Client
		WHERE id = @id
END
GO



CREATE OR ALTER PROCEDURE [dbo].[Get__AlbumSongs]
AS
BEGIN
		SELECT * FROM AlbumSong
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__AlbumSongs]
AS
BEGIN
		SELECT * FROM AlbumSong
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__AlbumSong]
	@id int
AS
BEGIN
		SELECT * FROM AlbumSong
		WHERE id = @id
END
GO



CREATE OR ALTER PROCEDURE [dbo].[Get__ArtistAlbums]
AS
BEGIN
		SELECT * FROM ArtistAlbum
		WHERE Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__ArtistAlbums]
AS
BEGIN
		SELECT * FROM ArtistAlbum
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetById__ArtistAlbum]
	@id int
AS
BEGIN
		SELECT * FROM ArtistAlbum
		WHERE id = @id
END
GO

/*POST*/


CREATE OR ALTER PROCEDURE [dbo].[Post__Song]
	@name nvarchar(MAX),
	@duration nvarchar(MAX)
AS
BEGIN
	INSERT INTO Song([Name],Duration,Active) 
	VALUES (@name,@duration,1)
	SELECT * FROM Song WHERE id = @@IDENTITY
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Post__Artist]
	@name nvarchar(MAX)
AS
BEGIN
	INSERT INTO Artist([Name],Active) 
	VALUES  (@name,1)
	SELECT * FROM Artist WHERE id = @@IDENTITY
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Post__Album]
	@name nvarchar(MAX),
	@descripcion nvarchar(MAX),
	@year nvarchar(MAX)
AS
BEGIN
	INSERT INTO Album([Name],[Description],[Year],Active) 
	VALUES (@name,@descripcion,@year,1)
	SELECT * FROM Album WHERE id = @@IDENTITY
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Post__User]
	@email nvarchar(MAX),
	@password nvarchar(MAX),
	@username nvarchar(MAX),
	@role nvarchar(MAX),
	@name nvarchar(MAX),
	@lastname nvarchar(MAX)
AS
BEGIN
	INSERT INTO [User](Email, [Password],Username,[Role],[Name],Lastname,Active) 
	VALUES (@email,@password,@username, @role,@name,@lastname,1)
	SELECT * FROM [User] WHERE id = @@IDENTITY
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Post__Client]
	@email nvarchar(MAX),
	@password nvarchar(MAX),
	@username nvarchar(MAX),
	@name nvarchar(MAX),
	@lastname nvarchar(MAX)
AS
BEGIN
	INSERT INTO [Client](Email, [Password],Username, [Name],Lastname,Active) 
	VALUES (@email,@password,@username,@name,@lastname,1)
	SELECT * FROM Client WHERE id = @@IDENTITY
END
GO



CREATE OR ALTER PROCEDURE [dbo].[Post__AlbumSong]
	@songId int,
	@albumId int
AS
BEGIN
	INSERT INTO AlbumSong(AlbumId, SongId,Active) 
	VALUES (@albumId,@songId,1)
	SELECT * FROM AlbumSong WHERE id = @@IDENTITY
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Post__ArtistAlbum]
	@albumId int,
    @artistId int
AS
BEGIN
	INSERT INTO ArtistAlbum(ArtistId,AlbumId,Active) 
	VALUES (@artistId,@albumId,1)
	SELECT * FROM ArtistAlbum WHERE id = @@IDENTITY
END
GO

/*PUT*/
CREATE OR ALTER PROCEDURE [dbo].[Put__Song]
	@id int,
	@name nvarchar(MAX),
	@duration nvarchar(MAX)
AS
BEGIN
	UPDATE Song SET 
		[Name] = @name,
		Duration = @duration,
		Active = 1
	WHERE Id = @id
	SELECT * FROM Song WHERE id = @id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Put__Artist]
	@id int,
	@name nvarchar(MAX)
AS
BEGIN
	UPDATE Artist SET 
		[Name] = @name,
		Active = 1
	WHERE Id = @id
	SELECT * FROM Artist WHERE id = @id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Put__Album]
	@id int,
	@name nvarchar(MAX),
	@descripcion nvarchar(MAX),
	@year nvarchar(MAX)
AS
BEGIN
	UPDATE Album SET 
		[Name] = @name,
		[Description] = @descripcion,
		[Year] = @year,
		Active = 1
	WHERE Id = @id
	SELECT * FROM Album WHERE id = @id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Put__User]
	@id int,
	@email nvarchar(MAX),
	@password nvarchar(MAX),
	@username nvarchar(MAX),
	@role nvarchar(MAX),
	@name nvarchar(MAX),
	@lastname nvarchar(MAX)
AS
BEGIN
	UPDATE [User] SET 
		Email = @email, 
		[Password] = @password,
		Username = @username,
		[Role] = @role,
		[Name] = @name,
		[Lastname]= @lastname,
		Active = 1
	WHERE Id = @id
	SELECT * FROM [User] WHERE id = @id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Put__Client]
	@id int,
	@email nvarchar(MAX),
	@password nvarchar(MAX),
	@username nvarchar(MAX),
	@name nvarchar(MAX),
	@lastname nvarchar(MAX)
AS
BEGIN
	UPDATE [Client] SET 
		Email = @email, 
		[Password] = @password,
		Username = @username,
		[Name] = @name,
		[Lastname]= @lastname,
		Active = 1
	WHERE Id = @id
	SELECT * FROM Client WHERE id = @id
END
GO



CREATE OR ALTER PROCEDURE [dbo].[Put__AlbumSong]
	@id int,
	@songId int,
	@albumId int
AS
BEGIN
	UPDATE AlbumSong SET 
		SongId = @songId,
		AlbumId = @albumId,
		Active = 1
	WHERE Id = @id
	SELECT * FROM AlbumSong WHERE id = @id
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Put__ArtistAlbum]
	@id int,
	@albumId int,
    @artistId int
AS
BEGIN
	UPDATE ArtistAlbum SET 
		AlbumId = @albumId,
		ArtistId = @albumId,
		Active = 1
	WHERE Id = @id
	SELECT * FROM ArtistAlbum WHERE id = @id
END
GO

/*SPECIAL*/


CREATE OR ALTER PROCEDURE [dbo].[Get__Albums_AllArtist]
AS
BEGIN
		SELECT ArtistAlbum.Id, Artist.Name AS 'Artist', Album.Name AS 'Album', Album.[Description], Album.[Year], Artist.Id AS 'ArtistId', Album.Id AS 'AlbumId' FROM ArtistAlbum
        INNER JOIN Artist
		ON Artist.Id = ArtistAlbum.ArtistId
        INNER JOIN Album
		ON Album.Id = ArtistAlbum.AlbumId
		WHERE Artist.Active = 1 AND Album.Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Albums_AllArtist]
AS
BEGIN
		SELECT ArtistAlbum.Id, Artist.Name AS 'Artist', Album.Name AS 'Album', Album.[Description], Album.[Year], Artist.Id AS 'ArtistId', Album.Id AS 'AlbumId' FROM ArtistAlbum
        INNER JOIN Artist
		ON Artist.Id = ArtistAlbum.ArtistId
        INNER JOIN Album
		ON Album.Id = ArtistAlbum.AlbumId
END
GO


CREATE OR ALTER PROCEDURE [dbo].[Get__Albums_ByArtist]
    @artistId int
AS
BEGIN
		SELECT ArtistAlbum.Id, Artist.Name AS 'Artist', Album.Name AS 'Album', Album.[Description], Album.[Year], Album.Id AS 'AlbumId' FROM ArtistAlbum
        INNER JOIN Artist
		ON Artist.Id = ArtistAlbum.ArtistId
        INNER JOIN Album
		ON Album.Id = ArtistAlbum.AlbumId
		WHERE Artist.Active = 1 AND Album.Active = 1 AND Artist.Id = @artistId
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Albums_ByArtist]
    @artistId int
AS
BEGIN
		SELECT ArtistAlbum.Id, Artist.Name AS 'Artist', Album.Name AS 'Album', Album.[Description], Album.[Year], Album.Id AS 'AlbumId' FROM ArtistAlbum
        INNER JOIN Artist
		ON Artist.Id = ArtistAlbum.ArtistId
        INNER JOIN Album
		ON Album.Id = ArtistAlbum.AlbumId
		WHERE Artist.Id = @artistId
END
GO


CREATE OR ALTER PROCEDURE [dbo].[Get__Album_ByArtist]
    @artistId int
AS
BEGIN
		SELECT Album.Id, Album.Name, Album.[Description], Album.[Year],Album.Active FROM ArtistAlbum
        INNER JOIN Artist
		ON Artist.Id = ArtistAlbum.ArtistId
        INNER JOIN Album
		ON Album.Id = ArtistAlbum.AlbumId
		WHERE Artist.Active = 1 AND Album.Active = 1 AND Artist.Id = @artistId
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Album_ByArtist]
    @artistId int
AS
BEGIN
		SELECT Album.Id, Album.Name, Album.[Description], Album.[Year],Album.Active FROM ArtistAlbum
        INNER JOIN Artist
		ON Artist.Id = ArtistAlbum.ArtistId
        INNER JOIN Album
		ON Album.Id = ArtistAlbum.AlbumId
		WHERE Artist.Id = @artistId
END
GO


CREATE OR ALTER PROCEDURE [dbo].[Get__Songs_AllAlbum]
AS
BEGIN
		SELECT AlbumSong.Id, Album.Name AS 'Album', Song.Name AS 'Song', Song.Duration, Album.Id AS 'AlbumId', Song.Id AS 'SongId' FROM AlbumSong
        INNER JOIN Album 
        ON Album.Id = AlbumSong.AlbumId
        INNER JOIN Song 
        ON Song.Id = AlbumSong.SongId
		WHERE Album.Active = 1 AND Song.Active = 1
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Songs_AllAlbum]
AS
BEGIN
		SELECT AlbumSong.Id, Album.Name AS 'Album', Song.Name AS 'Song', Song.Duration, Album.Id AS 'AlbumId', Song.Id AS 'SongId' FROM AlbumSong
        INNER JOIN Album 
        ON Album.Id = AlbumSong.AlbumId
        INNER JOIN Song 
        ON Song.Id = AlbumSong.SongId
END
GO


CREATE OR ALTER PROCEDURE [dbo].[Get__Songs_ByAlbum]
    @albumId int
AS
BEGIN
		SELECT AlbumSong.Id, Album.Name AS 'Album', Song.Name AS 'Song', Song.Duration, Song.Id AS 'SongId' FROM AlbumSong
        INNER JOIN Album 
        ON Album.Id = AlbumSong.AlbumId
        INNER JOIN Song 
        ON Song.Id = AlbumSong.SongId
		WHERE Album.Active = 1 AND Song.Active = 1 AND Album.Id = @albumId
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Songs_ByAlbum]
    @albumId int
AS
BEGIN
		SELECT AlbumSong.Id, Album.Name AS 'Album', Song.Name AS 'Song', Song.Duration, Song.Id AS 'SongId' FROM AlbumSong
        INNER JOIN Album 
        ON Album.Id = AlbumSong.AlbumId
        INNER JOIN Song 
        ON Song.Id = AlbumSong.SongId
		WHERE Album.Id = @albumId
END
GO

CREATE OR ALTER PROCEDURE [dbo].[Get__Song_ByAlbum]
    @albumId int
AS
BEGIN
		SELECT Song.Id, Song.Name, Song.Duration, Song.Active FROM AlbumSong
        INNER JOIN Album 
        ON Album.Id = AlbumSong.AlbumId
        INNER JOIN Song 
        ON Song.Id = AlbumSong.SongId
		WHERE Album.Active = 1 AND Song.Active = 1 AND Album.Id = @albumId
END
GO

CREATE OR ALTER PROCEDURE [dbo].[GetAll__Song_ByAlbum]
    @albumId int
AS
BEGIN
		SELECT Song.Id, Song.Name, Song.Duration, Song.Active FROM AlbumSong
        INNER JOIN Album 
        ON Album.Id = AlbumSong.AlbumId
        INNER JOIN Song 
        ON Song.Id = AlbumSong.SongId
		WHERE Album.Id = @albumId
END
GO