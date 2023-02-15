print '' print '*** creating sp_insert_score_by_game_id  - Toney Hale'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_score_by_game_id]
(
	@game_id	[int],
	@score		[nvarchar](1000)
)
AS
	BEGIN
		UPDATE [dbo].[GAME]
			SET [score] = @score
		WHERE
			@game_id = [game_id]
		RETURN
			@@ROWCOUNT
	END
GO