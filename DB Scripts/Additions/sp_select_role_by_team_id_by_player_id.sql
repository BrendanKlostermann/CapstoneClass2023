print '' print '*** creating sp_select_role_by_team_id_by_player_id Garion Opiola'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_select_role_by_team_id_by_member_id]
(
	@member_id			[int]
)
AS
	BEGIN
		SELECT 	[member_id],[team_id],[team_role_type_id]
		FROM 	[dbo].[TeamRole]
	END
GO
