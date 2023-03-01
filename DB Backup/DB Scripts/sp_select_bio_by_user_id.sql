print '' print '*** creating sp_select_bio_by_user_id Nick'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_bio_by_user_id]
(
		@member_id	 [int]
)
AS
	BEGIN
		SELECT [bio] 
		FROM [Member]
		WHERE [member_id] = @member_id
	END
GO