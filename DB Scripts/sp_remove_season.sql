/* Created by Nick Vroom */

print '' print '*** creating sp_remove_season by Nick Vroom'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_remove_season]
(
	@season_id				[int]	
)
AS
	BEGIN
		DELETE FROM [Season]
			WHERE	[season_id] 		= 	@season_id
	END
	RETURN @@ROWCOUNT
GO