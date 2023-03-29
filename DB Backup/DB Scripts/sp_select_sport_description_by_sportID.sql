print '' print '*** creating stored procedure sp_select_sports  -- Brendan K'
GO
USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_sports_description_by_sportID]
(
	@sportID	[int]
)
AS
	BEGIN
		SELECT [description] 
		FROM [dbo].[Sport]
		Where [sport_id] = @sportID
	END
GO
