/* login-related stored procedure */
print '' print '*** creating sp_authenticate_member  - Toney Hale'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_authenticate_user]
(
	@email 				[nvarchar](254),
	@passwordHash		[nvarchar](100)
)
AS
	BEGIN
		SELECT 	COUNT([member_id])
		FROM	[Member]
		WHERE	@email = [email]
		  AND	@passwordHash = [passwordHash]
		  AND	ACTIVE = 1;
	END
GO
