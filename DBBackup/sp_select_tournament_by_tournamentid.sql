/*
Created by Brendan Klostermann
sp_select_tournament_by_tournamentid
*/

print '' print  '*** Creating sp_select_tournament_by_tournamentid  - Brendan Klostermann'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_tournament_by_tournamentid]
(
	@tournamentid		int
)
AS
	BEGIN
		SELECT
			[tournament_id], [sport_id], [gender], [member_id], [name], [description], [active]
		FROM [dbo].[Tournament]
		WHERE	@tournamentid = [tournament_id]
	END
GO