/* Create SP for Updating Password */
/* 
Created By: Jacob Lindauer
Date: 02/01/2023

Description:
SP for resetting member passwords

Modification Histroy: 


*/

print '' print'*** creating sp_reset_password Jacob L***'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_reset_password](
	@member_id		[int],
	@old_password	[nvarchar](100),
	@new_password	[nvarchar](100)
)
AS
	BEGIN
		UPDATE 	[Member]
		SET		[passwordHash] = @new_password
		WHERE	@member_id = [member_id]
		AND 	@old_password = [passwordHash]
		
		RETURN @@ROWCOUNT
	END
GO
