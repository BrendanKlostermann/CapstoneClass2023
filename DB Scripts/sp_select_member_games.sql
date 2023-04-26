print '' print '*** Creating sp_select_member_games Jacob L ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_games](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			'Game'
			, [Game].[game_id]
			, [Venue].[venue_name]
			, [Game].[date_and_time]
		FROM [dbo].[GameRoster]
		JOIN [Game] ON [Game].[game_id] = [GameRoster].[game_id]
		JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
		WHERE [dbo].[GameRoster].[member_id] = @member_id
		AND [dbo].[Game].[Active] = 1
	END
GO

/*line 13 does not feel needed*/