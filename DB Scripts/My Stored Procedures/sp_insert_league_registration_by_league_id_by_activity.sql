/* Created by Elijah Morgan */

print '' print '*** creating sp_update_league_registration_by_league_id_by_activity'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_league_registration_by_league_id_by_activity]
(
	@league_id 	[int],
	@active		[bit]
)
AS 
	BEGIN
		UPDATE 	[League]
		SET 	[active] = @active
		WHERE	@league_id = [league_id]
		RETURN @@ROWCOUNT
	END
GO