print '' print '*** creating sp_insert_score_by_game_id  - Toney Hale'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_score_by_game_id]
(
	@game_id		[int],
	@team_id		[int],
	@score			[nvarchar](1000)
)
AS
	BEGIN
		INSERT INTO [dbo].[Score]([team_id], [game_id], [score])
		VALUES
			(@team_id, @game_id, @score)
		RETURN
			@@ROWCOUNT
	END
GO