
print '' print '*** creating store_procedure sp_update_user_bio by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_user_bio]
(
	@member_id		[int],
	@bio	 		[nvarchar](1000)
)
AS
	BEGIN
		UPDATE [dbo].[Member]
		SET [bio] = @bio
		WHERE [member_id] = @member_id
	END
GO