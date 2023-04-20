
print '' print '*** creating store_procedure sp_delete_generate_tournament_team by HERITIER'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_delete_generate_tournament_team]
(
	@tournament_id		[int]
)
AS
	BEGIN

        -- Create Table Temp to hold temporary data
        CREATE TABLE [dbo].[Temp] (
            [game_id]	        [int]	NOT NULL,
            [tournament_id]	    [int]	NOT NULL
            -- CONSTRAINT [fk_tournament_id_temp] FOREIGN KEY([tournament_id])
            --     REFERENCES [Tournament]([tournament_id]),
            -- CONSTRAINT [fk_TournamentGame_game_id_temp] FOREIGN KEY([game_id])
            --     REFERENCES [Game]([game_id]),
            -- CONSTRAINT [pk_TournamentGame_temp] PRIMARY KEY ([tournament_id], [game_id])
        )

        -- Insert Temp
		INSERT INTO [dbo].[Temp]
			([game_id], [tournament_id])
        SELECT [game_id], [tournament_id]
        FROM [dbo].[TournamentGame]
        WHERE [tournament_id] = @tournament_id

        -- -- SELECT [game_id]
        -- -- FROM [dbo].[TournamentGame]
        -- -- WHERE [tournament_id] = @tournament_id

        -- VolunteerSignUp
		DELETE FROM [dbo].[VolunteerSignUp]
		WHERE [volunteer_needed_id] IN (
            SELECT [volunteer_needed_id]
            FROM [dbo].[VolunteerNeeded]
        )

        -- VolunteerNeeded
		DELETE FROM [dbo].[VolunteerNeeded]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        -- TeamGame
		DELETE FROM [dbo].[TeamGame]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        -- Score
		DELETE FROM [dbo].[Score]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        -- GameRoster
		DELETE FROM [dbo].[GameRoster]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        -- GamePost
		DELETE FROM [dbo].[GamePost]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        -- TournamentGame
		DELETE FROM [dbo].[TournamentGame]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        -- Game
		DELETE FROM [dbo].[Game]
		WHERE [game_id] IN (
            SELECT [game_id]
            FROM [dbo].[Temp]
            WHERE [tournament_id] = @tournament_id
        )

        DROP TABLE [dbo].[Temp]

	END
GO