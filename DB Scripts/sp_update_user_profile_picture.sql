
print '' print '*** creating store_procedure sp_update_user_profile_picture by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_user_profile_picture]
(
	@member_id			[int],
	@profile_photo	 	[image]
)
AS
	BEGIN
		UPDATE [dbo].[Member]
		SET [profile_photo] = @profile_photo
		WHERE [member_id] = @member_id
	END
GO