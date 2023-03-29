
print '' print '*** creating store_procedure sp_delete_team_from_tournament by HERITIER'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_delete_team_from_tournament]
(
	@tournament_id		[int],
	@team_id			[int]
)
AS
	BEGIN
		DELETE FROM [dbo].[TournamentTeam]
		WHERE [tournament_id] = @tournament_id
		AND team_id = @team_id
	END
GO