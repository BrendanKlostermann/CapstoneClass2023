
print '' print '*** creating stored_procedure sp_select_team_by_member_id by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_by_member_id]
(
	@member_id			INT
)
AS
	BEGIN
		SELECT [TeamMember].[team_id], [TeamMember].[description],
                [TeamMember].[starter], [TeamMember].[member_id], 
                [Team].[team_name], [Team].[gender], 
                [Sport].[description]
		FROM [dbo].[TeamMember]
        INNER JOIN [dbo].[Team]
		ON [Team].[team_id] = [TeamMember].[team_id]
        INNER JOIN [dbo].[Sport]
		ON [Sport].[sport_id] = [Team].[sport_id]
		WHERE [TeamMember].[member_id] = @member_id
	END
GO

--like is used to find first name, last name, or email.
--=null is to help allow one part of the queery to be null