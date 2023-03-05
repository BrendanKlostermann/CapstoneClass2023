/* Created by Brendan Klostermann */

print '' print '*** creating sp_select_all_leagues_for_grid  --Brendan K'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_all_leagues_for_grid]
AS 
	BEGIN
		SELECT  [league_id], [sport_id], [member_id], [gender], [description], [name], [max_num_of_teams]			
		FROM 	[League]
	END
GO