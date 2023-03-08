
print '' print '*** creating stored_procedure sp_select_team_by_team_name by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_by_team_name]
(
	@team_name			[nvarchar](100) = NULL,
	@sport_id			[int] = NULL
	-- @season_id			[nvarchar](25) = NULL,
)
AS
	BEGIN

		-- Search for a team no matter the sport
		IF (@team_name != '' AND @sport_id=0)
			SELECT [team_id], [team_name], [gender], [Team].[sport_id], [Team].[description]
			FROM [dbo].[Team]
			INNER JOIN [dbo].[Sport]
			ON [Sport].[sport_id] = [Team].[sport_id]
			WHERE [team_name] 
			LIKE '%'+@team_name+'%'

		-- Search for a team by sport_ID
		ELSE IF (@team_name != '' AND @sport_id!=0)
			SELECT [team_id], [team_name], [gender], [Team].[sport_id], [Team].[description]
			FROM [dbo].[Team]
			INNER JOIN [dbo].[Sport]
			ON [Sport].[sport_id] = [Team].[sport_id]
			WHERE [team_name] 
			LIKE '%'+@team_name+'%'
			AND [Team].[sport_id] = @sport_id

		-- Select every team by sport_ID
		ELSE IF (@team_name = '' AND @sport_id!=0)
			SELECT [team_id], [team_name], [gender], [Team].[sport_id], [Team].[description]
			FROM [dbo].[Team]
			INNER JOIN [dbo].[Sport]
			ON [Sport].[sport_id] = [Team].[sport_id]
			AND [Team].[sport_id] = @sport_id

		-- If nothing is specify, show all teams 
		ELSE IF (@team_name = '' AND @sport_id=0)
			SELECT [team_id], [team_name], [gender], [Team].[sport_id], [Team].[description]
			FROM [dbo].[Team]
			INNER JOIN [dbo].[Sport]
			ON [Sport].[sport_id] = [Team].[sport_id]

		ELSE
			SELECT [team_id], [team_name], [gender], [sport_id]
			FROM [dbo].[Team]
		ENDIF
        
	END

--team name can be null and return all teams
