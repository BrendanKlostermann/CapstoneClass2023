/*
Heritier Otiom
Date: 03/04/2023

Description:
SP for acquiring all team equipment

*/

print '' print '*** Creating sp_select_team_equipment_by_name_or_sport_name_by_team_id -- HERITIER'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_team_equipment_by_name_or_sport_name_by_team_id](
	@name			[nvarchar](255) = NULL,
	@team_id		[int]
)
AS
	BEGIN
		IF (@name!='')
			SELECT
				[Equipment].[sport_id]
				, [Equipment].[description]
				, [TeamEquipmentList].[equipment_id]
				, [TeamEquipmentList].[team_id]
				, [TeamEquipmentList].[quantity]
				, [Sport].[description]
			FROM [dbo].[TeamEquipmentList]
			INNER JOIN [Equipment]
			ON [TeamEquipmentList].[equipment_id] = [Equipment].[equipment_id]
			INNER JOIN [Sport]
			ON [Sport].[sport_id] = [Equipment].[sport_id]
			WHERE [TeamEquipmentList].[team_id] = @team_id
			AND ([Equipment].[description] LIKE '%' + @name + '%'
            OR [Sport].[description] LIKE '%' + @name + '%'
            OR [TeamEquipmentList].[quantity] LIKE '%' + @name + '%')
		ELSE IF (@name='')
			SELECT
				[Equipment].[sport_id]
				, [Equipment].[description]
				, [TeamEquipmentList].[equipment_id]
				, [TeamEquipmentList].[team_id]
				, [TeamEquipmentList].[quantity]
				, [Sport].[description]
			FROM [dbo].[TeamEquipmentList]
			INNER JOIN [Equipment]
			ON [TeamEquipmentList].[equipment_id] = [Equipment].[equipment_id]
			INNER JOIN [Sport]
			ON [Sport].[sport_id] = [Equipment].[sport_id]
			WHERE [TeamEquipmentList].[team_id] = @team_id
		ELSE
			SELECT
				0 AS 'equipment_id'
				, 0 AS 'description'
				, 0 AS 'sport_id'
				, 0 AS 'sport_name'
				, 0 AS 'team_id'
				, 0 AS 'quantity'
			FROM [dbo].[TeamEquipmentList]
		ENDIF
	END
GO
