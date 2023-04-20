/* Create SP For Selecting Team */
/* 
-- Created By: Heritier Otiom
-- Date: 03/04/2023

Description:
SP for acquiring all tournament

*/

print '' print  '*** Creating sp_select_tournament_games -- Heritier'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_tournament_games]
(
    @tournament_id          [int]
)
AS
	BEGIN
		SELECT
			[TournamentGame].[tournament_id]
			, [TournamentGame].[game_id]
			, [TeamGame].[team_id]
		FROM [dbo].[TournamentGame]
        INNER JOIN [dbo].[TeamGame]
        ON [TournamentGame].[game_id] = [TeamGame].[game_id]
	END
GO
