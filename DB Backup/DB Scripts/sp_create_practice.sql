
print '' print '*** creating store_procedure sp_create_practice by Nick Vroom'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_create_practice]
(
	@team_id			[int],
	@location			[nvarchar](250),
	@date_time			[smalldatetime],
	@description		[nvarchar](1000)
)
AS
	BEGIN
		INSERT INTO [dbo].[Practice]
			([team_id], [location],[date_time],[description])
		VALUES
			(@team_id, @location, @date_time, @description)
	END
GO




