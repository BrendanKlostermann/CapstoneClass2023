print '' print '*** Creating sp_insert_venue | Jacob Lindauer***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_venue](
	@venue_name		[nvarchar](25)
	, @parking		[nvarchar](250)
	, @description	[nvarchar](2500)
	, @location		[nvarchar](250)
	, @zip_code		[int]
)
AS
	BEGIN
		INSERT INTO [venue]
			([venue_name], [parking], [description], [location], [zip_code])
		VALUES
			(@venue_name, @parking, @description, @location, @zip_code)
			
		SELECT SCOPE_IDENTITY()
	END
GO
