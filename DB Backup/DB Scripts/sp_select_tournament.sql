/* Create SP For Selecting Team */
/* 
-- Created By: Heritier Otiom
-- Date: 03/04/2023

Description:
SP for acquiring all tournament

*/

print '' print  '*** Creating sp_select_tournament -- Heritier'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_tournament]
AS
	BEGIN
		SELECT
			[tournament_id]
			, [sport_id]
			, [gender]
			, [member_id]
			, [name]
			, [description]
			, [active]
		FROM [dbo].[Tournament]
	END
GO
