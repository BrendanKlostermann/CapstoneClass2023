/* Created by Elijah Morgan */

print '' print '*** creating sp_update_league Eli'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_league]
(
	@league_id			[int],
	@member_id			[int],
	@sport_id			[int],					
	@league_dues		[money],				
	@active				[bit],									 	
	@gender				[bit],					
	@description		[nvarchar](1000),		
	@name				[nvarchar](250),
	@max_num_of_teams 	[int]
)
AS
	BEGIN
		UPDATE 		[League]
			SET		[league_dues]		=	@league_dues,
					[active]			=	@active,
					[description]		=	@description,
					[name]				=	@name,
					[max_num_of_teams] 	= 	@max_num_of_teams
			WHERE		@league_id 			= 	[league_id]
				AND		@member_id			= 	[member_id]
				AND		@sport_id			=	[sport_id]
				AND		@league_dues		=	[league_dues]
				AND		@active				=	[active]
				AND		@gender				=	[gender]
				AND 	@name				=	[name]
				AND 	@max_num_of_teams 	=   [max_num_of_teams]
		RETURN 	@@ROWCOUNT
	END
GO