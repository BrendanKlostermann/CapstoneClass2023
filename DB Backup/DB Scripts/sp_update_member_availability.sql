print '' print '*** Creating sp_update_member_availability  Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_member_availability](
	@member_id					[int]
	, @availability_id			[int]
	, @start_availability		[datetime]
	, @end_availability			[datetime]
	, @description				[nvarchar](250)	
)
AS
	BEGIN
		UPDATE [dbo].[Availability]
		SET
			[start_availability] = @start_availability
			, [end_availability] = @end_availability
			, [description] = @description
		WHERE [member_id] = @member_id AND availability_id = @availability_id
	END
GO