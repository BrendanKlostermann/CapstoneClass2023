print '' print '*** creating stored_procedure sp_add_member_to_team_by_member_id_and_team_id -alex'
GO

USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_add_member_to_team_by_member_id_and_team_id]
    @team_id INT,
    @member_id INT
AS
BEGIN
    INSERT INTO [dbo].[TeamMember] ([team_id], [member_id])
    VALUES (@team_id,@member_id);
	
	RETURN @@ROWCOUNT
END;