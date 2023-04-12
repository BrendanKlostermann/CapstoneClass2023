print '' print'*** creating sp_select_score_by_game_id ***'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_score_by_game_id](
	@game_id	[int]
)
AS
	BEGIN
		SELECT
			[team_id],
			[score]
		FROM [dbo].[Score]
		WHERE [game_id] = @game_id
	END
GO