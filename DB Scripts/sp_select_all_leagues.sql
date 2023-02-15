/* Created by Elijah Morgan */

print '' print '*** creating sp_select_all_leagues'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_all_leagues]
AS 
	BEGIN
		SELECT  [league_id], [sport_id], [league_dues], [active], [member_id], [gender], [description], [name], [max_num_of_teams]			
		FROM 	[League]
	END
GO