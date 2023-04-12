print '' print '*** Creating sp_deactivate_game | Jacob Lindauer ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_deactivate_game](
	@game_id				[int]
)
AS
	BEGIN
		UPDATE [dbo].[Game]
		SET [active] = 0
		WHERE [game_id] = @game_id	
	END
GO
	