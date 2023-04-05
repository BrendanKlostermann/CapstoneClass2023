/*
Heritier Otiom
Date: 03/04/2023

Description:
SP for acquiring all tournament

*/

print '' print '*** Creating sp_select_tournament_team_by_tournament_id -- Heritier'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_tournament_team_by_tournament_id](
	@tournament_id INT
)
AS
	BEGIN
		SELECT
			[tournament_id]
			, [team_id]
		FROM [dbo].[TournamentTeam]
		WHERE [tournament_id] = @tournament_id
	END
GO
