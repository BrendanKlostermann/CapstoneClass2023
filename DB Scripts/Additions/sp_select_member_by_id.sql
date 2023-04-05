
print '' print '*** creating stored_procedure sp_select_member_by_id by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_by_id]
(
	@member_id			INT
)
AS
	BEGIN
		SELECT [member_id],[email],[first_name],[family_name],[birthday],
			[phone_number],[gender],[active],[bio],[profile_photo] 
		FROM [dbo].[Member]
		WHERE [member_id] = @member_id
	END
GO

--like is used to find first name, last name, or email.
--=null is to help allow one part of the queery to be null