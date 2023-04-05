/* Created by Toney Hale */

print '' print '*** creating sp_open_or_close_tournament_registration_by_tournament_id Toney Hale'
GO

USE	[ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_open_or_close_tournament_registration_by_tournament_id]
(
	@tournament_id	[int],
	@active			[bit]
)
AS 
	BEGIN
		UPDATE 	[Tournament]
		SET 	[active] = @active
		
		WHERE	[tournament_id] = @tournament_id
		
		RETURN @@ROWCOUNT
	END
GO