
print '' print '*** creating store_procedure sp_insert_tournament_game by Nick Vroom'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_insert_tournament_game]
(
	@tournament_id		[int]
)
AS
BEGIN
	INSERT INTO [dbo].[TournamentGame]
		([tournament_id])
	VALUES
		(@tournament_id)
END
GO
