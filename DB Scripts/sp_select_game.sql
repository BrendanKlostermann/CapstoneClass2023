/* Created by Gideon trevor */

print '' print '*** creating sp_select_game Gideon Trevor'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_game]
AS 
	BEGIN
		SELECT  [game_id],[score],[venue_id],[date_and_time],[sport_id]			
		FROM 	[dbo].[Game]
	END
GO