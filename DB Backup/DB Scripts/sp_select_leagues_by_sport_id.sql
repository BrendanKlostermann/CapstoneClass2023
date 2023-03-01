/* Created by Elijah Morgan */

print '' print '*** creating sp_select_leagues_by_sport_id -Eli'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_leagues_by_sport_id]
(
	@sport_id [int]
)
AS 
	BEGIN
		SELECT  [league_id], [sport_id], [league_dues], [League].[gender], [description], [name], [max_num_of_teams]
		FROM 	[League]
		WHERE 	@sport_id = [sport_id]
	END
GO