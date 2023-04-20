/* Created by Rith */

print '' print '*** creating sp_select_request_by_league_id Rith S'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_request_by_league_id]
(
@LeagueID int
)
AS 
	BEGIN
		SELECT  [request_id],[team_id],[status]		
		FROM 	[dbo].[LeagueRequest]
		WHERE [league_id]=@LeagueID
	END
GO