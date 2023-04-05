

print '' print '*** creating stored_procedure sp_select_members_by_name_and_or_email -alex'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_members_by_name_and_or_email]
(
	@first_name		[nvarchar](25) = NULL,
	@family_name	[nvarchar](25) = NULL,
	@email			[nvarchar](254) = NULL
)
AS
BEGIN
	IF (@first_name IS NOT NULL OR @family_name IS NOT NULL OR @email IS NOT NULL)
	BEGIN
		SELECT [member_id],[email],[first_name],[family_name],[birthday],
			[phone_number],[gender],[active],[bio],[profile_photo] 
		FROM [dbo].[Member]
		WHERE (@first_name IS NULL OR [first_name] LIKE '%'+@first_name+'%')
			AND (@family_name IS NULL OR [family_name] LIKE '%'+@family_name+'%')
			AND (@email IS NULL OR [email] LIKE '%'+@email+'%')
	END
	ELSE 
	BEGIN
		SELECT [member_id],[email],[first_name],[family_name],[birthday],
			[phone_number],[gender],[active],[bio],[profile_photo] 
		FROM [dbo].[Member]
	END
END
GO