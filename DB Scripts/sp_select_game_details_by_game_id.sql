/* Create SP for Selecting Game Details by Game ID */
/* 
Created By: Jacob Lindauer
Date: 02/12/2023

Description:
SP for acquiring game details by game_id


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
			, [Venue].[venue_name]
			, [Venue].[location]
			, CONCAT([zipcode].[city], ', ', [zipcode].[st], ' ', [zipcode].[zip_code])
			, [Game].[date_and_time]
			, [Sport].[description]
			, [Game].[member_id]
			FROM [Game]
			JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
			JOIN [Sport] ON [Game].[sport_id] = [Sport].[sport_id]
			JOIN [zipcode] ON [zipcode].[zip_code] = [Venue].[zip_code]
			WHERE @game_id = [Game].[game_id]
	END
GO
			