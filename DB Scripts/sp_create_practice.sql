
print '' print '*** creating store_procedure sp_create_practice by Nick Vroom'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_create_practice]
(
    @team_id        [int],
    @location       [nvarchar](250),
    @date_time      [smalldatetime],
    @description    [nvarchar](1000),
    @zipcode        [int]
)
AS
BEGIN
    INSERT INTO [dbo].[Practice]
        ([team_id], [location], [date_time], [description], [zip_code])
    VALUES
        (@team_id, @location, @date_time, @description, @zipcode)
END



