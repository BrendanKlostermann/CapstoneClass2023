-- Created By Rith

print'' print'*** Creating  sp_create_league -Rith S'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_create_league]
(
	@SportID		int,
	@Dues			money,
	@Active			bit,
	@MemberID	 	int,
	@Gender			bit,
	@Description	varchar(1000),
	@Name			varchar(250),
	@Max_Num_Teams	int
)
AS
	BEGIN
		INSERT INTO [League]
		([sport_id], [league_dues], [active], [member_id], [gender], [description], [name], [max_num_of_teams])
		VALUES
		(@SportID, @Dues, @Active, @MemberID, @Gender, @Description, @Name, @Max_Num_Teams)
		SELECT SCOPE_IDENTITY()
	END