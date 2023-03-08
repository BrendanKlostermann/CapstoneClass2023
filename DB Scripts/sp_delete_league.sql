-- Created By Rith

print'' print'*** Creating  sp_delete_league -Rith S'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_delete_league]
(
	@LeagueID		int
)
AS
	BEGIN
		DELETE FROM [League]
		WHERE @LeagueID = [league_id]
	END
GO