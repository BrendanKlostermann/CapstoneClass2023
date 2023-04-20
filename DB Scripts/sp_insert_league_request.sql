/* Created by Rith */

print '' print '*** creating sp_insert_league_request Rith S'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_insert_league_request]
(
@LeagueID int,
@TeamID int,
@Status [nvarchar] (250)
)
AS 
	BEGIN
		
		INSERT INTO [LeagueRequest]([league_id],[team_id],[status])		
		VALUES (@LeagueID, @TeamID, @Status)
	END
GO