/* Created by Brendan K */

print '' print 'Creating sp_update_tournament Brendan K'

GO

use [ecgo_db]
go

CREATE PROCEDURE [dbo].[sp_update_tournament]
(
	@tournamentid	int,
	@sportid		int,
    @gender 		bit,
	@memberid		int,
	@name			nvarchar(250),
	@description	nvarchar(1000),
	@editorID		int
	
)
AS
BEGIN
    
    BEGIN TRY
        BEGIN TRANSACTION
        
        UPDATE 	[Tournament]
			SET		[Sport_ID]		=	@sportID,
					[Gender]		=	@gender,
					[member_id]		=	@memberid,
					[name]			=	@name,
					[description]	=	@description
					
			WHERE	[tournament_ID] = 	@tournamentID
			AND 	[Member_ID]		= 	@editorID
		RETURN 	@@ROWCOUNT
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; --Rollback any changed made if failed
    END CATCH
END
