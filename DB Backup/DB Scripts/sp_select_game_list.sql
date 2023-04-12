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
				, [Venue].[venue_name] AS 'Location'
				, [Game].[date_and_time] AS 'Date and Time'
		FROM [Game]
			JOIN [GameRoster] ON [GameRoster].[game_id] = [Game].[game_id]
			JOIN [Venue] ON [Venue].[venue_id] = [Game].[venue_id]
			JOIN [Team] ON [Team].[team_id] = [GameRoster].[team_id]
		WHERE [Game].[active] = 1;
	END
GO