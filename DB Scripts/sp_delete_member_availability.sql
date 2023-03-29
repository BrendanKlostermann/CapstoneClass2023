print '' print '*** Creating sp_delete_member_availability by Jacob L'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_delete_member_availability]
(
	@member_id			[int],
	@availability_id	[int]
)
AS
	BEGIN
		DELETE FROM [dbo].[Availability]
		WHERE [availability_id] = @availability_id
		AND [member_id] = @member_id
	END
GO