/* Created by Elijah Morgan */

print '' print '*** creating sp_select_league_by_league_id'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_league_by_league_id]
(
	@league_id 	[int]
)
AS 
	BEGIN
		SELECT  [sport_id], [league_dues], [active], [member_id], [gender], [description], [name], [max_num_of_teams]
		FROM 	[League]
		WHERE	@league_id = [league_id]
		RETURN @@ROWCOUNT
	END
GO