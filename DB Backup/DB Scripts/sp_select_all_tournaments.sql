-- Created By Brendan

print'' print'*** Creating  sp_select_all_tournaments - Brendan K'
GO

USE [ecgo_db]
GO



CREATE PROCEDURE [dbo].[sp_select_all_tournaments]
AS    
    BEGIN
        SELECT	[tournament_id],[sport_id],[gender],[member_id],[name],[description],[active]
		FROM [Tournament]
		Where [active] = 1
    END
GO