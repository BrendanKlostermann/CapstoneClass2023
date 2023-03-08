
print '' print '*** creating stored_procedure sp_select_members_by_name by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_members_by_name]
(
	@name			[nvarchar](100) = NULL
)
AS
	BEGIN
		IF @name != ''
			SELECT [member_id],[email],[first_name],[family_name],[birthday],
				[phone_number],[gender],[active],[bio],[profile_photo] 
			FROM [dbo].[Member]
			WHERE [first_name] LIKE '%'+@name+'%' OR [family_name] 
			LIKE '%'+@name+'%' OR [email] LIKE '%'+@name+'%'
		ELSE 
			SELECT [member_id],[email],[first_name],[family_name],[birthday],
				[phone_number],[gender],[active],[bio],[profile_photo] FROM [dbo].[Member]
		ENDIF
        
	END
GO

--like is used to find first name, last name, or email.
--=null is to help allow one part of the queery to be null