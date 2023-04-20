-- Created By Nick

print'' print'*** Creating  sp_select_seasons_by_league_id -Nick V'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_seasons_by_league_id]
(
	@league_id		int
)
AS
	BEGIN
		SELECT [season_id], [league_id], [description], [sport_id]
		FROM [Season]
		WHERE @league_id = [league_id]
	END
GO