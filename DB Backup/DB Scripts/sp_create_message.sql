
print '' print '*** creating store_procedure sp_create_message by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_create_message]
(
	@user_id_sender			[int],
	@user_id_reciever		[int],
	@date_and_time			[datetime],
	@important				[bit],
	@message				[nvarchar](4000)
)
AS
	BEGIN
		INSERT INTO [dbo].[Message]
			([user_id_sender], [user_id_reciever],[date_and_time], [important], [message])
		VALUES
			(@user_id_sender, @user_id_reciever, @date_and_time, @important, @message)
	END
GO