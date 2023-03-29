print '' print '*** creating store_procedure sp_update_teamMember_to_bench_or_starter by Alex'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_teamMember_to_bench_or_starter]
(
	@team_id			[int],		
	@starter			[bit],	
	@member_id			[int]
)

AS
	BEGIN
		UPDATE [dbo].[TeamMember]
		SET [starter] = @starter
		WHERE [team_id] = @team_id AND [member_id] = @member_id
	END
GO