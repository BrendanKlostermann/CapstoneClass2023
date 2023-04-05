-- Created By Rith

print'' print'*** Creating  sp_add_team_to_league -Rith S'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_add_team_to_league]
(
	@TeamID		int,
	@LeagueID   int
)
AS
	BEGIN
		INSERT INTO [LeagueTeam]
		([league_id], [team_id])
		VALUES
		(@TeamID, @LeagueID)
	END
GO