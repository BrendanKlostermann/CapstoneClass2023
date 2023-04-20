/*
Created by HERITIER Otiom
*/

print'' print'*** Creating  sp_activate_tournament - HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_activate_tournament]
(
    @memberid		int,
	@tournamentid	int
)
AS    
    BEGIN
        update	[Tournament]
		set		[active] = 1
		WHERE	[tournament_ID] = 	@tournamentid
			AND 	[Member_ID]		= 	@memberid
		RETURN 	@@ROWCOUNT
    END
GO