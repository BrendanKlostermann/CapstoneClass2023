print '' print '*** creating sp_update_game_score_by_team_id | Jacob Lindauer'
GO

USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_update_game_score_by_team_id]
(
	@game_id	[int],
	@team_id	[int],
	@score	NVARCHAR(1000),
	@old_team_id	[int]
)
AS
	BEGIN
		UPDATE 	[Score]
		SET		[score] = @score
				, [team_id] = @team_id
		WHERE	[game_id] = @game_id
		AND		[team_id] = @old_team_id
		RETURN 	@@ROWCOUNT
	END
GO