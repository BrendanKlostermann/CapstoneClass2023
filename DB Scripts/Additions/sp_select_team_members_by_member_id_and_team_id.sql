print '' print '*** creating sp_select_team_members_by_member_id_and_team_id - Alex Korte'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_members_by_member_id_and_team_id]
(
    @member_id		int,
	@team_id		int	
)
AS    
    BEGIN
		SELECT [TeamMember].[team_id], [description], [starter], [TeamMember].[member_id]
		FROM [TeamMember]
		WHERE @member_id = [TeamMember].[member_id]
		AND @team_id = [TeamMember].[team_id]
    END
GO 