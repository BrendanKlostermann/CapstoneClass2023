/* Created by Rith S */

print '' print '*** creating sp_update_league_request_status_by_request_id Rith'
GO

USE	[ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_league_request_status_by_request_id]
(
	@RequestID int,
	@Status varchar(250)
)
AS
	BEGIN
		UPDATE 	[LeagueRequest]
			SET		[status]		=	@Status
			WHERE	[request_id] 		= 	@RequestID
		RETURN 	@@ROWCOUNT
	END
GO