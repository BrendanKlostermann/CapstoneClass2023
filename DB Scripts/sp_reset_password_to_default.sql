/* Created by Michael Haring */

print '' print '*** creating sp_reset_password_to_default Mike'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_reset_password_to_default]
@member_id int
AS
BEGIN
UPDATE [dbo].[Member]
SET [passwordHash] = '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E'
WHERE [member_id] = @member_id
END
GO