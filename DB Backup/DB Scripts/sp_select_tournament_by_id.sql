print '' print '*** Creating sp_select_tournament_by_id by Nick Vroom***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_tournament_by_id]
(
	@tournament_id		[int]
)
AS
	BEGIN
		SELECT [Tournament].[tournament_id], [Sport].[description], [Tournament].[gender], [Tournament].[name], [Tournament].[description], [Tournament].[member_id]
		FROM [Tournament]
		JOIN [Sport]
		ON [Tournament].[sport_id] = [Sport].[sport_id]
		WHERE @tournament_id = [tournament_id];
	END
GO