
print '' print '*** creating stored_procedure sp_select_team_by_team_name by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_by_team_name]
(
	@team_name			[nvarchar](100) = NULL
)
AS
	BEGIN
		IF @team_name != ''
			SELECT [team_id], [team_name], [gender], [sport_id] 
			FROM [dbo].[Team] 
			WHERE [team_name] 
			LIKE '%'+@team_name+'%'
		ELSE 
			SELECT [team_id], [team_name], [gender], [sport_id] 
			FROM [dbo].[Team]
		ENDIF
        
	END
GO

--team name can be null and return all teams
