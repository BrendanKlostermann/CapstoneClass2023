/* Created by Elijah Morgan */

print '' print '*** creating sp_select_active_league_by_status Eli M'
GO

USE	[ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_active_leagues_by_status]
(
	@active		[bit]
)
AS 
	BEGIN
		SELECT  [league_id], [sport_id], [league_dues], [League].[gender], [description], [name]
		FROM 	[League] JOIN [Member]
			ON 	[League].[member_id] = [Member].[member_id]
		WHERE	[League].[active] = 1
	END
GO