
print '' print '*** creating store_procedure sp_user_create_team by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_user_create_team]
(
	@team_name			[nvarchar](100),
	@gender				[bit] = NULL,
	@sport_id			[int],
	@member_id			[int]
)
AS
	BEGIN
		DECLARE @team_id INT;
		-- Create the team
		INSERT INTO [dbo].[Team]
			([team_name], [gender],[sport_id],[member_id])
		VALUES
			(@team_name, @gender, @sport_id, @member_id)

		-- Select the team_id created above
		SELECT @team_id = [team_id] FROM [dbo].[Team]
		WHERE [team_name] = @team_name

		-- Add me as member of that team
		INSERT INTO [dbo].[TeamMember]
			([team_id], [description], [starter],[member_id])
		VALUES
			(@team_id, 'Team Captain', 1, @member_id)
	END
GO

--gender can be null