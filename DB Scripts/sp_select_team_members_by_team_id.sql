print '' print '*** Creating sp_select_team_members_by_team_id ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_members_by_team_id](
		@team_id		[int]
)
AS
	BEGIN
		SELECT
			[description]
			, [starter]
			, [member_id]
		FROM [dbo].[TeamMember]
		WHERE [team_id] = @team_id
	END
GO