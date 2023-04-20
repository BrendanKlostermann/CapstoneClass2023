
print '' print '*** creating store_procedure sp_insert_team_to_tournament by HERITIER'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_insert_team_to_tournament]
(
	@tournament_id		[int],
	@team_id			[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[TournamentTeam]
			([tournament_id], [team_id])
		VALUES
			(@tournament_id, @team_id)
	END
GO