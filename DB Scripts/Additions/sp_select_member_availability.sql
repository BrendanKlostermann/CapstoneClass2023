print '' print '*** Creating sp_select_member_availability Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_availability](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			'Availability'
			, [availability_id]
			, [start_availability]
			, [end_availability]
			, [description]
		FROM [dbo].[Availability]
		WHERE [dbo].[Availability].[member_id] = @member_id
	END
GO