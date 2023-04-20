print '' print '*** creating sp_select_all_roles -- michael haring ***'

USE [ecgo_db]
GO

GO
CREATE PROCEDURE [sp_select_all_roles]
AS
BEGIN
	SELECT [role_id]
	FROM [dbo].[Role]
	ORDER BY [role_id]
END
GO