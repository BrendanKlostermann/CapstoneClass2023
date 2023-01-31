print'' print'*** Creating deactivate user'
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

