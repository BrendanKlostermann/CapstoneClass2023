/* Created by Elijah Morgan */

print '' print '*** creating sp_update_league'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_league]
(
	@league_id				[int],
	
	@newLeague_dues			[money],				
	@newActive				[bit],									 	
	@newGender				[bit],					
	@newDescription			[nvarchar](1000),		
	@newName				[nvarchar](250),
	@newMax_num_of_teams 	[int]
)
AS
	BEGIN
		UPDATE 	[League]
			SET		[league_dues]		=	@newLeague_dues,
					[active]			=	@newActive,
					[gender]			=	@newGender,
					[description]		=	@newDescription,
					[name]				=	@newName,
					[max_num_of_teams] 	= 	@newMax_num_of_teams
			WHERE	[league_id] 		= 	@league_id
		RETURN 	@@ROWCOUNT
	END
GO