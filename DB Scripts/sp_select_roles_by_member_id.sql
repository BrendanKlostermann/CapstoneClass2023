print '' print '*** Creating sp_select_roles_by_member_id | Jacob Lindauer***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_roles_by_member_id](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			[Role].[description]
		FROM [Role]
		JOIN [MemberRole] ON [MemberRole].[role_id] = [Role].[role_id]
		WHERE [MemberRole].[member_id] = @member_id
	END
GO
