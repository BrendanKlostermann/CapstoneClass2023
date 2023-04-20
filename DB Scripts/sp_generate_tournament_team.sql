
print '' print '*** creating store_procedure sp_generate_tournament_team by HERITIER'
GO

USE [ecgo_db]
GO


CREATE PROCEDURE [dbo].[sp_generate_tournament_team]
(
	@tournament_id		[int],

	@team_id_1			[int],
	@team_id_2			[int],
	@member_id			[int],

	@content			[nvarchar](1000),
	@group				[int]
)
AS
	BEGIN

		-- Game
		DECLARE @game_id INT
		DECLARE @venue_id INT
		DECLARE @date_and_time DATETIME
		DECLARE @sport_id INT

		DECLARE @player_1 INT
		DECLARE @player_2 INT

		DECLARE @game_roster_id_1 INT
		DECLARE @game_roster_id_2 INT

		-- Select Random venue
		SELECT @venue_id = [venue_id]
		FROM [dbo].[Venue]
        ORDER BY NEWID()

        -- Select Random date_and_time
		SELECT @date_and_time = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 365), '2023-05-01')
        FROM [dbo].[Member]
        ORDER BY NEWID()

		-- Select sport_id
        SELECT @sport_id = [sport_id]
        FROM [dbo].[Tournament]
        WHERE [tournament_id] = @tournament_id

        -- Insert Game
		INSERT INTO [dbo].[Game]
			([venue_id], [date_and_time], [sport_id])
		VALUES
			(@venue_id, @date_and_time, @sport_id)

        -- Get game_id
        SELECT @game_id = SCOPE_IDENTITY()

        -- Insert GamePost
		INSERT INTO [dbo].[GamePost]
			([game_id], [member_id], [content], [date_time])
		VALUES
			(@game_id, @member_id, @content, @date_and_time)

        -- Select Random player on team_id_1
		SELECT @player_1 = [member_id]
		FROM [dbo].[TeamMember]
        WHERE [team_id] = @team_id_1
        ORDER BY NEWID()

        -- Select Random player on team_id_2
        SELECT @player_2 = [member_id]
		FROM [dbo].[TeamMember]
        WHERE [team_id] = @team_id_2
        ORDER BY NEWID()

        -- Insert GameRoster_1
		INSERT INTO [dbo].[GameRoster]
			([game_id], [team_id], [member_id], [description])
		VALUES
			(@game_id, @team_id_1, @player_1, "Team Captain")

        -- Get game_roster_id_1
        SELECT @game_roster_id_1 = SCOPE_IDENTITY()
        
        -- Insert GameRoster_2
		INSERT INTO [dbo].[GameRoster]
			([game_id], [team_id], [member_id], [description])
		VALUES
			(@game_id, @team_id_2, @player_2, "Team Captain")

        -- Get game_roster_id_2
        SELECT @game_roster_id_2 = SCOPE_IDENTITY()

        
        
        -- Insert TournamentGame
		INSERT INTO [dbo].[TournamentGame]
			([tournament_id], [game_id])
		VALUES
			(@tournament_id, @game_id)

        -- Insert Score
		INSERT INTO [dbo].[Score]
			([game_id], [team_id], [score])
		VALUES
			(@game_id, @team_id_1, 0),
			(@game_id, @team_id_2, 0)

        -- Insert TeamGame
		INSERT INTO [dbo].[TeamGame]
			([team_id], [win], [game_id], [game_roster_id])
		VALUES
			(@team_id_1, 0, @game_id, @game_roster_id_1),
			(@team_id_2, 0, @game_id, @game_roster_id_2)


	END
GO