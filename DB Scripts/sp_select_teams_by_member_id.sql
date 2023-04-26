print '' print '*** creating sp_select_teams_by_member_id Alex Korte***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_teams_by_member_id]
    (@member_id INT)
AS
	BEGIN
		SELECT [Team].[team_id], [team_name], [Team].[gender], [sport_id], [Team].[member_id], [Team].[description]
		FROM [dbo].[Team]
		WHERE member_id = @member_id
	END
GO