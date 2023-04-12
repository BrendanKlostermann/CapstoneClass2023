/* Create Proceudre to obtain game list */
print '' print '*** Creating sp_select_game_list Jacob***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_game_list]
AS
	BEGIN
		SELECT
			DISTINCT([Game].[game_id])
			, [Sport].[description] AS 'Sport'
			, [Venue].[venue_name] AS 'Location'
			, [Game].[date_and_time] AS 'Date and Time'
		FROM [Game]
		JOIN [GameRoster] ON [GameRoster].[game_id] = [Game].[game_id]
		JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
		JOIN [Sport] ON [Sport].[sport_id] = [Game].[sport_id]
		WHERE [Game].[active] = 1
		ORDER BY [Game].[date_and_time]
	END
GO