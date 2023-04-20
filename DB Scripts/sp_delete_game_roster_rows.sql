print '' print '*** Creating sp_delete_game_roster_rows | Jacob Lindauer ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_delete_game_roster_rows](
		@team_id	[int]
		, @game_id	[int]
)
AS
	BEGIN
		
		DELETE FROM [TeamGame]
		WHERE [game_roster_id] IN (SELECT DISTINCT[game_roster_id] FROM [GameRoster] WHERE [team_id] = @team_id AND [game_id] = @game_id)
		
		DELETE FROM [GameRoster]
		WHERE [game_id] = @game_id AND [team_id] = @team_id
		
		SELECT @@ROWCOUNT
	END
GO