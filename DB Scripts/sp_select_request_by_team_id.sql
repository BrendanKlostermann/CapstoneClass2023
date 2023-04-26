/* Created by Alex */

print '' print '*** creating sp_select_request_by_team_id Alex'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_request_by_team_id]
(
@TeamID int
)
AS 
	BEGIN
		SELECT  [team_request_id],[member_id],[team_id],[status]		
		FROM 	[dbo].[TeamRequest]
		WHERE [team_id]=@TeamID
	END
GO