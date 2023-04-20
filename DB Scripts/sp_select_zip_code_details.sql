print '' print '*** Creating sp_select_zip_code_details | Jacob Lindauer ***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_zip_code_details](
		@zipCode		[int]
)
AS
	BEGIN
		SELECT
			[zip_code] AS 'Zipcode'
			, [city] AS 'City'
			, [st] AS 'State'
		FROM [dbo].[zipcode]
		WHERE [zip_code] = @zipCode
	END
GO