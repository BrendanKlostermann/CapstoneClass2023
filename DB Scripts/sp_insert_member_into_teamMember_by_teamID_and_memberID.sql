print '' print '*** Creating sp_insert_member_into_teamMember_by_teamID_and_memberID  -alex korte ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_member_into_teamMember_by_teamID_and_memberID]
(
	@team_id 		int,		
	@member_id		int
)
AS 
	BEGIN	
		INSERT INTO [TeamMember]
		([team_id], [member_id])
		VALUES
		(@team_id, @member_id)
	END
GO
