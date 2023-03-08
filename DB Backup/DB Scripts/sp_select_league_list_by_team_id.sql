/* Create SP for Selecting League List by Team ID*/
/* 
Created By: Jacob Lindauer
Date: 02/27/2023

Description:
SP for selecting League List by TeamID

Modification Histroy: 


*/
print '' print'*** creating sp_select_league_list_by_team_id Jacob L***'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_league_list_by_team_id](
	@team_id	[int]
)
AS
	BEGIN
		SELECT  [League].[league_id]
			, [League].[sport_id]
			, [League].[league_dues]
			, [League].[active]
			, [League].[member_id]
			, [League].[gender]
			, [League].[description]
			, [League].[name]
			, [League].[max_num_of_teams]			
		FROM 	[League]
		JOIN 	[dbo].[LeagueTeam] ON [LeagueTeam].[league_id] = [League].[league_id]
		WHERE 	@team_id = [LeagueTeam].[team_id]
	END
GO