print '' print '*** creating sp_select_teams_by_league_id Alex Korte***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_all_teams]
AS
	BEGIN
		SELECT [Team].[team_id], [team_name], [Team].[gender], [sport_id], [Team].[member_id], [Team].[description], [active]
		FROM [dbo].[Team]
	END
GO