print '' print '*** Creating sp_insert_member_availability  Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_member_availability](
	@member_id					[int]
	, @start_availability		[datetime]
	, @end_availability			[datetime]
	, @description				[nvarchar](250)	
)
AS
	BEGIN
		INSERT INTO [dbo].[Availability](
			[member_id], [start_availability], [end_availability], [description])
		VALUES 
			(@member_id, @start_availability, @end_availability, @description)
	END
GO