print '' print '*** creating sp_deactivate_own_team Garion ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_deactivate_own_team]
(
	@team_id	[int],
	@member_id	[int]
)
AS
	BEGIN
		UPDATE [dbo].[Team]
		SET [active] = 0	
		WHERE [team_id] = @team_id
		AND [member_id] = @member_id
	END
GO
