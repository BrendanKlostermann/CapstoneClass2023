
print '' print '*** creating stored_procedure sp_select_messages_by_user_id by HERITIER'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_messages_by_user_id]
(
	@member_id				[int],
	@otherMemberId			[int]
)
AS
	BEGIN
		SELECT 
			[message_id]
			, [user_id_sender]
			, [user_id_reciever] 
			, [date_and_time]
			, [important]
			, [message]
			, [Member].[profile_photo]
        FROM [dbo].[Message]
        INNER JOIN [Member]
        ON [Member].[member_id] = [Message].[user_id_sender]
        -- AND [User].[user_id] = [Message].[user_id_reciever]
        WHERE ([user_id_sender] = @member_id AND [user_id_reciever] = @otherMemberId)
        OR ([user_id_sender] = @otherMemberId AND [user_id_reciever] = @member_id)
        ORDER BY [date_and_time] ASC
	END
GO
