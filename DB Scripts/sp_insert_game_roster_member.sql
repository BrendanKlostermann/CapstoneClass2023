print '' print '*** Creating sp_insert_game_roster_member | Jacob Lindauer ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_game_roster_member](
		@member_id			[int],
		@team_id			[int],
		@description		[nvarchar](250),
		@game_id			[int]
)
AS
	BEGIN
		INSERT INTO [GameRoster]
			([team_id], [member_id], [description], [game_id])
		VALUES
			(@team_id, @member_id, @description, @game_id)
	END
GO