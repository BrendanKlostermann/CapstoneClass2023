
print '' print '*** creating store_procedure sp_delete_team_equipment by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_delete_team_equipment]
(
	@equipment_id		[int],
	@team_id			[int]
)
AS
	BEGIN
		-- DELETE FROM [dbo].[Equipment]
		-- WHERE [equipment_id] = @equipment_id;

		DELETE FROM [dbo].[TeamEquipmentList]
		WHERE [equipment_id] = @equipment_id
		AND [team_id] = @team_id

	END
GO