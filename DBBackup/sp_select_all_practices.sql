print '' print '*** creating sp_select_all_practices Nick Vroom***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_all_practices]
(
	@team_id				[int]	
)
AS
	BEGIN
		SELECT [Practice].[practice_id], [location], [team_id], [date_time], [description], [zip_code]
		FROM [dbo].[Practice]
		WHERE [team_id] = @team_id;
	END
GO