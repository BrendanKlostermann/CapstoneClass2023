print '' print '*** creating sp_select_teams_by_league_id Rith***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_teams_by_league_id]
(
	@league_id int
)
AS
	BEGIN
		SELECT [Team].[team_id], [team_name], [Team].[gender], [Team].[sport_id], [Team].[member_id], [Team].[description]
		FROM [dbo].[Team] 
			JOIN [LeagueTeam] 
				ON [Team].[team_id] = [LeagueTeam].[team_id] 
			JOIN [League]
				ON [League].[league_id] = [LeagueTeam].[league_id]
		WHERE [LeagueTeam].[league_id] = @league_id
	END
GO