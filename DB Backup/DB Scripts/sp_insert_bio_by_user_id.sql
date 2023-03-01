print '' print '*** creating sp_insert_bio_by_user_id Nick'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_bio_by_user_id]
(
	@member_id	 [int],
	@bio		 [NVARCHAR](1000)
)
AS
	BEGIN
		UPDATE [dbo].[Member]
		SET [bio] = @bio
		WHERE 
		[member_id] = @member_id
		RETURN @@ROWCOUNT
	END
GO