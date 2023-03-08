/* Create SP for Selecting Game Details by Game ID */
/* 
Created By: Jacob Lindauer
Date: 02/12/2023

Description:
SP for acquiring game details by game_id

Modification Histroy: 

		updated by Gideon Trevor
		Date: 02/28/2023
		      adding a way to return the Score since 
		      it is part of the game table and needed in the details


*/
print '' print'*** creating sp_select_game_details_by_game_id ***'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_game_details_by_game_id](
	@game_id	[int]
)
AS
	BEGIN
		SELECT
			DISTINCT [Game].[game_id]
			, [Venue].[location]
			, [Venue].[city]
			, [Venue].[zip_code]
			, [Venue].[venue_name]
			, [Game].[date_and_time]
			, [Sport].[description]
			, [Game].[Score]
			FROM [Game]
			JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
			JOIN [GameRoster] ON [GameRoster].[game_id] = [Game].[game_id]
			JOIN [Team] ON [Team].[team_id] = [GameRoster].[team_id]
			JOIN [Sport] ON [Game].[sport_id] = [Sport].[sport_id]
			WHERE @game_id = [Game].[game_id]
	END
GO
			