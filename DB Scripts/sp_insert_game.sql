print '' print '*** Creating sp_insert_game | Jacob Lindauer ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_game](
	@venue_id				[int],
	@date_and_time			[dateTime],
	@sport_id				[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[Game] 
			([venue_id], [date_and_time], [sport_id])
		VALUES
			(@venue_id, @date_and_time, @sport_id)
			
	END
GO
	