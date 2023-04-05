
print '' print '*** creating store_procedure sp_update_team_equipment by HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_update_team_equipment]
(
	@equipment_id		[int],
	@quantity	 		[int],
	@sport_id	 		[int],
	@description	 	[nvarchar](255),
	@team_id			[int]
)
AS
	BEGIN
		UPDATE [dbo].[Equipment]
		SET [description] = @description,
            [sport_id] = @sport_id
		WHERE [equipment_id] = @equipment_id;

        
		UPDATE [dbo].[TeamEquipmentList]
		SET [quantity] = @quantity
		WHERE [equipment_id] = @equipment_id
        AND [team_id] = @team_id;
	END
GO