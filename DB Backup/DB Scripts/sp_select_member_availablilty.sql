print '' print '*** Creating sp_select_member_availablilty Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_availablilty](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			'Availability'
			, [availability_id]
			, [start_availability]
			, [end_availability]
		FROM [dbo].[Availability]
		WHERE [dbo].[Availability].[member_id] = @member_id
	END
GO