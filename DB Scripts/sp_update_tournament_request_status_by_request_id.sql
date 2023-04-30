/* Created by Alex korte */

print '' print '*** creating sp_update_tournament_request_status_by_request_id Alex K'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_tournament_request_status_by_request_id]
(
	@RequestID int,
	@Status varchar(250)
)
AS
	BEGIN
		UPDATE 	[TournamentRequest]
			SET		[status]		=	@Status
			WHERE	[tournament_request_id] 		= 	@RequestID
		RETURN 	@@ROWCOUNT
	END
GO