print '' print '*** creating sp_update_registration_by_league_id Rith'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_registration_by_league_id]
(
	@Active     [bit],
	@league_id	[int]
)
AS 
	BEGIN
		UPDATE  [League]
		SET	[Active] = @Active
		WHERE	@league_id = [League_id]
		RETURN @@ROWCOUNT
	END
GO