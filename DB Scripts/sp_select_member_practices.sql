print '' print '*** Creating sp_select_member_practices  Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_practices](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			'Practice'
			, [Practice].[practice_id]
			, [Practice].[location]
			, [Practice].[date_time]
		FROM [dbo].[TeamRole]
		JOIN [dbo].[Team] ON [Team].[team_id] = [TeamRole].[team_id]
		JOIN [dbo].[Practice] ON [Practice].[team_id] = [Team].[team_id]
		WHERE [dbo].[TeamRole].[member_id] = @member_id
	END
GO