/* Created by Gideon trevor 
   Date: 02/28/2023
*/

print '' print '*** creating sp_update_game_score_by_game_id Gideon Trevor'
GO

USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_update_game_score_by_game_id]
(
	@game_id	[int],
	@team_id	[int],
	@score	NVARCHAR(1000)
)
AS
	BEGIN
		UPDATE 	[Score]
		SET		[score] = @score
		WHERE	[game_id] = @game_id
		AND		[team_id] = @team_id
		RETURN 	@@ROWCOUNT
	END
GO