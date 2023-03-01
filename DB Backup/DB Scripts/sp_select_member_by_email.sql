/* Create SP for Selecting Member by Email */
/* 
Created By: Jacob Lindauer
Date: 02/05/2023

Description:
SP for selecting member from member_id

Modification Histroy: 


*/

print '' print'*** creating sp_select_member_by_email Jacob L***'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_by_email](
		@email		[nvarchar](254)
)
AS
	BEGIN
		SELECT
			[member_id]		
            , [email]			
            , [first_name]	
            , [family_name]	
            , [birthday]		
            , [phone_number]	
            , [gender]		
            , [active]		
            , [bio]			
            , [profile_photo]	
		FROM [dbo].[Member]
		WHERE @email = [email]
	END
GO