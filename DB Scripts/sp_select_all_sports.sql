-- Created By Rith

print'' print'*** Creating  sp_select_all_sports -Rith S'
GO

USE [ecgo_db]
GO



CREATE PROCEDURE [dbo].[sp_select_all_sports]
AS    
    BEGIN
        SELECT	[sport_id],[description]
		FROM [Sport]
    END
GO