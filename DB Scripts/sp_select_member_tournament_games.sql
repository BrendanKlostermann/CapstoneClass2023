print '' print '*** Creating sp_select_member_tournament_games Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_tournament_games](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			'Tournament Game'
			, [Game].[game_id]
			, [Venue].[venue_name]
			, [Game].[date_and_time]
		FROM [dbo].[GameRoster]
		JOIN [Game] ON [Game].[game_id] = [GameRoster].[game_id]
		JOIN [TournamentGame] ON [TournamentGame].[game_id] = [Game].[game_id]
		JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
		WHERE [dbo].[GameRoster].[member_id] = @member_id
		AND [dbo].[Game].[Active] = 1
	END
GO