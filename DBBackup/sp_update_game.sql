print '' print '*** Creating sp_update_game | Jacob Lindauer ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_game](
	@game_id				[int],
	@venue_id				[int],
	@date_and_time			[dateTime],
	@sport_id				[int],
	@member_id				[int]
)
AS
	BEGIN
		UPDATE [dbo].[Game]
		SET [venue_id] = @venue_id
			, [date_and_time] = @date_and_time
			, [sport_id] = @sport_id
		WHERE [game_id] = @game_id	AND [Game].[member_id] = @member_id
	END
GO
	