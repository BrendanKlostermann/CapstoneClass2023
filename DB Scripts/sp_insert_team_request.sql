/* Created by Alex */

print '' print '*** creating sp_insert_team_request Alex K'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_insert_team_request]
(
@TeamID int,
@MemberID int
)
AS 
	BEGIN
		
		INSERT INTO [TeamRequest]([member_id],[team_id])		
		VALUES (@MemberID, @TeamID)
	END
GO