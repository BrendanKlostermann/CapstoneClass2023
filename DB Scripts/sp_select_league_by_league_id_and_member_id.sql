/* Created by Elijah Morgan */

print '' print '*** creating sp_select_league_by_league_id_and_member_id Elijah Morgan'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_league_by_league_id_and_member_id]
(
	@league_id 	[int],
	@member_id	[int]
)
AS 
	BEGIN
		SELECT  [sport_id], [league_dues], [active], [gender], [description], [name]
		FROM 	[League]
		WHERE	@league_id = [league_id]
		AND		@member_id = [Member_id]
		RETURN @@ROWCOUNT
	END
GO