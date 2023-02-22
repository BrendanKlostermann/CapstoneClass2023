/* Create SP for Selecting Game Roster */
/* 
Created By: Jacob Lindauer
Date: 02/05/2023

Description:
SP for acquiring game rosters from game_id

Modification Histroy: 


*/
print '' print'*** creating sp_select_game_roster_by_game_id Jacob L***'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_game_roster_by_game_id](
	@game_id	[int]
)
AS
	BEGIN
		SELECT
			[GameRoster].[game_roster_id]
			, [GameRoster].[game_id]
			, [GameRoster].[member_id]
			, [GameRoster].[description]
			, [GameRoster].[team_id]
			, [Team].[team_name]
			, [Member].[first_name]
			, [Member].[family_name]
		FROM [dbo].[GameRoster]
		JOIN [Team]
			ON [Team].[team_id] = [GameRoster].[team_id]
		JOIN [Member]
			ON [Member].[member_id] = [GameRoster].[member_id]
		WHERE @game_id = [GameRoster].[game_id]
	END
GO
			