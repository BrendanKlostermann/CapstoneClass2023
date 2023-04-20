
print '' print '*** creating stored_procedure sp_select_sports by HERITIER'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_sports]
AS
	BEGIN
		SELECT [sport_id], [description] 
		FROM [dbo].[Sport] 
		ORDER BY [description]
	END
GO

