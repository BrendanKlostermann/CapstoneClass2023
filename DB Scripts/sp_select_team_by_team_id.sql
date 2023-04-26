/* Create SP For Selecting Team */
/* 
Created By: Jacob Lindauer
Date: 02/05/2023

Description:
SP for acquiring team by team ID

Modification Histroy: 


*/

print '*** Creating sp_select_team_by_team_id Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_by_team_id](
	@team_id	[int]
)
AS
	BEGIN
		SELECT
			[team_id]
			, [team_name]
			, [gender]
			, [sport_id]
			, [member_id]
		FROM [dbo].[Team]
		WHERE @team_id = [team_id]
	END
GO
