
print '' print '*** creating store_procedure sp_insert_user_account by HERITIER'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_insert_user_account]
(
	@first_name			[nvarchar](25),
	@family_name		[nvarchar](25),
	@gender				[bit],
	@birthday			[date],
	@phone_number		[nvarchar](15),
	@email				[nvarchar](254),
	@passwordHash		[nvarchar](100),
	@active				[bit],
	@profile_photo 		[image]
)
AS
	BEGIN
		INSERT INTO [dbo].[Member]
			([first_name], [family_name],[gender], [birthday], [phone_number], [email], 
				[passwordHash], [active], [profile_photo])
		VALUES
			(@first_name, @family_name, @gender, @birthday, @phone_number, 
			@email, @passwordHash, @active, @profile_photo)
	END
GO