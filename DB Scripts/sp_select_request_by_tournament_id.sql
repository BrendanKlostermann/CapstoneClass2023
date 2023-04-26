/* Created by Alex */

print '' print '*** creating sp_select_request_by_tournament_id Alex'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_request_by_tournament_id]
(
@TournamentID int
)
AS 
	BEGIN
		SELECT  [tournament_request_id],[tournament_id],[team_id],[status]		
		FROM 	[dbo].[TournamentRequest]
		WHERE [tournament_id]=@TournamentID
	END
GO