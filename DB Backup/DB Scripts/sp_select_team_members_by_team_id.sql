/* created by Jacob Lindauer */
print '' print '*** Creating sp_select_team_members_by_team_id ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_members_by_team_id](
		@teamid			[int]
)
AS
	BEGIN
		SELECT
			[description]
			, [member_id]
			, [starter]
		FROM [TeamMember]
		WHERE [team_id] = @teamid
	END
GO
	