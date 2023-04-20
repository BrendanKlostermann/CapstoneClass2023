/* Created by Rith */

print '' print '*** creating sp_select_leagues_by_member_id Rith'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_leagues_by_member_id]
(
	@member_id	[int]
)
AS 
	BEGIN
		SELECT  [league_id], [sport_id], [league_dues], [active], [member_id],[gender], [description], [name],[max_num_of_teams]
		FROM 	[League]
		WHERE	@member_id = [Member_id]
		RETURN @@ROWCOUNT
	END
GO