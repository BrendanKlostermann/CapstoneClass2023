
print '' print '*** creating stored_procedure sp_select_owner_by_team_id by Nick Vroom'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_owner_by_team_id]
(
	@team_id			INT
)
AS
	BEGIN
		SELECT [member_id]
		FROM [dbo].[Team]
		WHERE [team_id] = @team_id
	END
GO