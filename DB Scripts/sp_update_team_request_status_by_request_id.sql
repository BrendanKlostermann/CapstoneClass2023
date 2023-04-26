/* Created by Alex korte */

print '' print '*** creating sp_update_team_request_status_by_request_id Alex K'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_team_request_status_by_request_id]
(
	@RequestID int,
	@Status varchar(250)
)
AS
	BEGIN
		UPDATE 	[TeamRequest]
			SET		[status]		=	@Status
			WHERE	[team_request_id] 		= 	@RequestID
		RETURN 	@@ROWCOUNT
	END
GO