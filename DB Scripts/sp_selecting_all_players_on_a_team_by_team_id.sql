print '' print '*** creating sp_ selecting_all_players_on_a_team_by_team_id Alex Korte***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_selecting_all_players_on_a_team_by_team_id]
(
	@team_id		[int]
)
AS
	BEGIN
		SELECT [Member].[member_id], [email], [first_name], [family_name], [birthday], [phone_number], [gender], [active], [bio], [profile_photo], [PhotoMimeType]
		FROM [dbo].[TeamMember]
		INNER JOIN [dbo].[Member]
		ON [Member].[member_id] = [TeamMember].[member_id]
		WHERE @team_id = [TeamMember].[team_id]
	END
GO