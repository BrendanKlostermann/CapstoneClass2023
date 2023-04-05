/* Created by Nick Vroom */

print '' print '*** creating sp_update_season by Nick Vroom'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_season]
(
	@season_id				[int],				
	@description			[nvarchar](250)		
)
AS
	BEGIN
		UPDATE 	[Season]
			SET		[description]		=	@description
			WHERE	[season_id] 		= 	@season_id
	END
	RETURN @@ROWCOUNT
GO