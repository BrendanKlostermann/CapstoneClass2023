print '' print '*** creating store_procedure sp_delete_practice by Garion'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_delete_practice]
(
    @Practice_id     int 
)
AS
BEGIN
    DELETE FROM [Practice]
    WHERE @Practice_id = [practice_id]
END
GO