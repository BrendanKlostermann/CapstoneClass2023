print '' print '*** creating sp_remove_a_player_from_team_by_member_id Alex Korte***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_remove_a_player_from_team_by_member_id]
(
	@team_id		[int],
	@member_id		[int]
)
AS	
	BEGIN
		DELETE 
		FROM [TeamMember]
		WHERE @member_id = [member_id]
		AND @team_id = [team_id]
		
		RETURN @@ROWCOUNT
	END
GO