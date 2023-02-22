
print '' print '*** creating store_procedure sp_user_create_team by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_user_create_team]
(
	@team_name			[nvarchar](100),
	@gender				[bit] = NULL,
	@sport_id			[int]
)
AS
	BEGIN
		INSERT INTO [dbo].[Team]
			([team_name], [gender],[sport_id])
		VALUES
			(@team_name, @gender, @sport_id)
	END
GO

--gender can be null