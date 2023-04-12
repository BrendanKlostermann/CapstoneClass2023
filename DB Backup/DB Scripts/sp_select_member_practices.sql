print '' print '*** Creating sp_select_member_practices  Jacob L***'
GO

USE [ecgo_db]
GO

CREATE PROCEDURE [dbo].[sp_select_member_practices](
	@member_id		[int]
)
AS
	BEGIN
		SELECT
			'Practice'
			, [Practice].[practice_id]
			, CONCAT([Practice].[location] , " " , [Practice].[city] ,  ", " , [Practice].[state_name] , " " , [Practice].[zip_code])
			, [Practice].[date_time]
			, [Practice].[description]
		FROM [dbo].[TeamMember]
		JOIN [dbo].[Team] ON [Team].[team_id] = [TeamMember].[team_id]
		JOIN [dbo].[Practice] ON [Practice].[team_id] = [Team].[team_id]
		WHERE [dbo].[TeamMember].[member_id] = @member_id
	END
GO