-- Created By Brendan Klostermann

print'' print'*** Creating  sp_deactivate_member -Brendan K'
GO

USE [ecgo_db]
GO



CREATE PROCEDURE [dbo].[sp_deactivate_member]
(
    @member_id		int
)
AS    
    BEGIN
        update	[Member]
		set		[Active] = 0
		where 	@member_id = [member_id]
        
        RETURN @@ROWCOUNT
    END
GO