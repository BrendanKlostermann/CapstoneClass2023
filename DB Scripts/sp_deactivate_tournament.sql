/*
Created by Brendan Klostermann
*/

print'' print'*** Creating  sp_deactivate_tournament -Brendan K'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_deactivate_tournament]
(
    @memberid		int,
	@tournamentid	int
)
AS    
    BEGIN
        update	[Tournament]
		set		[active] = 0
		WHERE	[tournament_ID] = 	@tournamentid
			AND 	[Member_ID]		= 	@memberid
		RETURN 	@@ROWCOUNT
    END
GO