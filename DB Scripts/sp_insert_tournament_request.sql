/* Created by Alex */

print '' print '*** creating sp_insert_tournament_request Alex K'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_insert_tournament_request]
(
@TeamID int,
@TournamentID int
)
AS 
	BEGIN
		
		INSERT INTO [TournamentRequest]([tournament_id],[team_id])		
		VALUES (@TournamentID, @TeamID)
	END
GO