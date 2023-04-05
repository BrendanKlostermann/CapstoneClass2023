/* Created by Brendan K */

print '' print 'Creating sp_insert_tournament Brendan K'

GO

use [ecgo_db]
go

CREATE PROCEDURE [dbo].[usp_InsertData]
(
	@sportid		int,
    @Gender 		bit,
	@memberid		int,
	@name			nvarchar(250),
	@description	nvarchar(1000)
	
)
AS
BEGIN
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO [dbo].[Tournament] 
			([Sport_ID],[Gender],[member_id],[name],[description],[active])
        VALUES (@sportid, @Gender, @memberid, @name, @description, 1);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; --Rollback any changed made if failed
    END CATCH
END
