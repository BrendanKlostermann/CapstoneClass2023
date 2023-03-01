
print '' print '*** creating stored_procedure sp_select_people_I_texted_by_user_id by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_people_I_texted_by_user_id]
(
	@member_id				[int]
)
AS
	BEGIN
		SELECT 
        
			-- CONCAT([Message].[message_id], " ", [Message].[user_id_sender], " ", [Message].[user_id_reciever]) AS Message,
            
            [Member].[member_id], [Member].[email], [Member].[first_name],
            [Member].[family_name], [Member].[profile_photo]
            
        FROM [dbo].[Message]
        INNER JOIN [dbo].[Member]
        ON [Message].[user_id_sender] = [Member].[member_id]
        OR [Message].[user_id_reciever] = [Member].[member_id]
        WHERE ([Message].[user_id_sender] = @member_id OR [Message].[user_id_reciever] = @member_id)
        GROUP BY [Member].[member_id], [Member].[email], [Member].[first_name],
            [Member].[family_name], [Member].[profile_photo]
	END
GO
