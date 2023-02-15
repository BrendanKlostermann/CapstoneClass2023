/* Create Proceudre to obtain game list */
/*
Created By: Jacob Lindauer
Date: 02/08/2023

Description:
Sproc will retieve data to view in game list.
GameID is needed so when row is selected we can obtain what gameID the user wants to view.

For XML Path takes selected query results and puts them on one line. 
This formats the query to give <team>Team1Name</team><team>Team2Name</team>
PATH will format this to be Team1NameTeam2Name

By adding the + ' VS ' to the select line formats the values to be Team1Name VS Team2Name VS
After substinging to remove that we are now getting correct results. 

*/
USE [ecgo_db]
GO

print '' print '*** Creating sp_select_game_list ***'
GO
CREATE PROCEDURE [dbo].[sp_select_game_list]
AS
	BEGIN
			SELECT
				DISTINCT([Game].[game_id])
				, SUBSTRING((SELECT DISTINCT([Team].[team_name]) + ' VS '
					FROM [GameRoster]
					JOIN [Team] ON [Team].[team_id] = [GameRoster].[team_id]
					WHERE [GameRoster].[game_id] = [Game].[game_id]
					FOR XML PATH ('')), 1
						, LEN((SELECT DISTINCT([Team].[team_name]) + ' VS '
						FROM [GameRoster]
						JOIN [Team] ON [Team].[team_id] = [GameRoster].[team_id]
						WHERE [GameRoster].[game_id] = [Game].[game_id]
						FOR XML PATH ('')))-2) AS 'Teams'
				, [Venue].[location] AS 'Location'
				, [Game].[date_and_time] 'Date and Time'
			FROM [Game]
				JOIN [GameRoster] ON [GameRoster].[game_id] = [Game].[game_id]
				JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
	END
GO