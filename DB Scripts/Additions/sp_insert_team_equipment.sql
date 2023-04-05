
print '' print '*** creating store_procedure sp_insert_team_equipment by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_insert_team_equipment]
(
	@description		[nvarchar](255),
	@sport_id			[int],
	@quantity			[int],
	@team_id			[int]
)
AS
	BEGIN
		DECLARE @equipment_id INT;
		-- Create the team
		INSERT INTO [dbo].[Equipment]
			([sport_id], [description])
		VALUES
			(@sport_id, @description)

        SELECT @equipment_id = SCOPE_IDENTITY();

		-- Add me as member of that team
		INSERT INTO [dbo].[TeamEquipmentList]
			([equipment_id], [team_id], [quantity])
		VALUES
			(@equipment_id, @team_id, @quantity)
	END
GO
