/* Created by Gideon trevor */

print '' print '*** creating sp_select_venue Gideon Trevor'
GO

USE [ecgo_db]
GO
CREATE PROCEDURE [dbo].[sp_select_venue]
AS 
	BEGIN
		SELECT  [venue_id],[venue_name],[parking],[description],[location],[zipcode].[zip_code],[zipcode].[city], [zipcode].[st]			
		FROM 	[Venue]
		JOIN [zipcode] ON [zipcode].[zip_code] = [Venue].[zip_code]
	END
GO