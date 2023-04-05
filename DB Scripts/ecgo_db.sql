/* check whether the database exists, and if so, delete it. */
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = "ecgo_db")
BEGIN
	DROP DATABASE ecgo_db
	print "" print "*** dropping database ecgo_db"
END
GO

print "" print "*** creating database ecgo_db"
GO
CREATE DATABASE ecgo_db
GO

print "" print "*** using database ecgo_db"
GO
USE [ecgo_db]
GO

print '' print '*** creating Member table Elijah Morgan'
GO
CREATE TABLE [dbo].[Member]
(
	[member_id]		[int] IDENTITY(100000,1)	NOT NULL,
	[email]			[nvarchar](254) 			NOT	NULL,
	[first_name]	[nvarchar](25)				NOT NULL,
	[family_name]	[nvarchar](25)				NOT NULL,
	[birthday]		[date] 						NOT NULL,
	[phone_number]	[nvarchar](15) 					NULL,
	[passwordHash]	[nvarchar](100) 			NOT NULL DEFAULT
		'9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E',
	[gender]		[bit] 							NULL,
	[active]		[bit] 						NOT NULL DEFAULT 1,
	[bio]			[nvarchar] (1000)		 		NULL,
	[profile_photo]	[varbinary](MAX) 				NULL,
	[PhotoMimeType] [varchar](50)					NULL,
	CONSTRAINT [pk_member_id] PRIMARY KEY([member_id]),
	CONSTRAINT [ak_email] Unique ([email])
)
GO

Print '' Print '*** Creating Table AdminRole | Jacob Lindauer ***'
GO
CREATE TABLE [dbo].[AdminRole] (
	[admin_role_id]				[nvarchar](255)		NOT NULL,
	[admin_role_type]			[nvarchar](200)		NOT NULL,
	CONSTRAINT	[pk_admin_role_id]	
		PRIMARY KEY ([admin_role_id])
)
GO

print '' print '*** Creating Table Role - Brendan'
GO
create table[dbo].[Role](
	[role_id]		[nvarchar](50)						not null,
	[description]	[nvarchar](250)						not null,
	constraint 		[pk_role_id]	primary key([role_id])
);
GO

print '' print '*** creating LeagueRole table - Toney Hale'
GO
CREATE TABLE [dbo].[LeagueRole] 
(
	[league_role_id]	[nvarchar](20)				NOT NULL,
	[description]		[nvarchar](250)				NULL,
	CONSTRAINT [pk_league_role_id] 	PRIMARY KEY ([league_role_id])
)
GO

print '' print '*** creating Sport table Nick Vroom'
GO
CREATE TABLE [dbo].[Sport] (
	[sport_id] 		[int] IDENTITY(1000,1) 	NOT NULL,
	[description] 	[nvarchar](250) 		NOT NULL,
	CONSTRAINT [pk_sport_id] PRIMARY KEY([sport_id])
)
GO

print '' print '*** creating league table Rith'
GO
CREATE TABLE [dbo].[League] (
	[league_id]			[int] IDENTITY(1000,1)	NOT NULL,
	[sport_id]			[int]					NOT NULL,
	[league_dues]		[money]					NULL,
	[active]			[bit]					NOT NULL,	
	[member_id]			[int]				 	NOT NULL,
	[gender]			[bit]					NULL,
	[description]		[nvarchar](1000)		NULL,
	[name]				[nvarchar](250)			NOT NULL,
	[max_num_of_teams]	[int]					NULL
	CONSTRAINT [fk_sport_id] FOREIGN KEY([sport_id])
		REFERENCES [Sport]([sport_id]),
	CONSTRAINT [fk_member_id] FOREIGN KEY([member_id])
		REFERENCES [Member]([member_id]),
	CONSTRAINT [pk_league_id] PRIMARY KEY([league_id])
)
GO

print '' print '*** creating LeagueRoleAssignment table - Toney Hale'
GO
CREATE TABLE [dbo].[LeagueRoleAssignment]
(
	[member_id]			[int] 						NOT NULL,
	[league_role_id]	[nvarchar](20)				NOT NULL,
	[league_id]			[int]						NOT NULL,
	CONSTRAINT 			[fk_LeagueRoleAssignment_member_id] 
		FOREIGN KEY ([member_id]) REFERENCES [dbo].[Member]([member_id]),
	CONSTRAINT 			[fk_LeagueRoleAssignment_league_role_id] 
		FOREIGN KEY ([league_role_id]) REFERENCES [dbo].[LeagueRole]([league_role_id]),
	CONSTRAINT 			[fk_LeagueRoleAssignment_league_id] 
		FOREIGN KEY ([league_id]) REFERENCES [dbo].[League]([league_id]),
	CONSTRAINT			[pk_LeagueRolesAssignment]
		PRIMARY KEY ([member_id], [league_role_id], [league_id])
)
GO

print "" print "*** create team table -- Heritier"
GO
CREATE TABLE [dbo].[Team] (
	[team_id]				[int] IDENTITY(1000, 1)			NOT NULL,
    [team_name]				[nvarchar](50)					NULL,
	[active]				[bit]							NULL DEFAULT 1,
	[gender]				[bit]							NULL,
	[sport_id]				[int]							NOT NULL,
	[member_id]				[int]							NOT NULL,
	[description]           [nvarchar](1000)              	NULL,	
	CONSTRAINT [pk_team_id] PRIMARY KEY([team_id]),
    CONSTRAINT [fk_teamSport_id] FOREIGN KEY([sport_id]) REFERENCES [dbo].[Sport]([sport_id]),
	CONSTRAINT [fk_team_coach] FOREIGN KEY ([member_id]) REFERENCES [dbo].[member]([member_id]),
	CONSTRAINT [ak_team_name] Unique ([team_name])
)
GO

print '' print '*** creating LeagueTeam table - Toney Hale'
GO
CREATE TABLE [dbo].[LeagueTeam] 
(
	[league_id]		[int] 				NOT NULL,
	[team_id]		[int]				NOT NULL,
	CONSTRAINT 			[fk_LeagueTeam_league_id] 
		FOREIGN KEY ([league_id]) REFERENCES [dbo].[League]([league_id]),
	CONSTRAINT 			[fk_LeagueTeam_team_id] 
		FOREIGN KEY ([team_id]) REFERENCES [dbo].[Team]([team_id]),
	CONSTRAINT			[pk_LeagueTeam]
		PRIMARY KEY ([league_id], [team_id])
)
GO

print "" print "*** create table TeamMember -- Heritier"
GO
CREATE TABLE [dbo].[TeamMember] (
	[team_id]				[int]							NOT NULL,
    [description]			[nvarchar](25)					NULL,
	[starter]				[bit]							NOT NULL DEFAULT 0,	
	[member_id]				[int]							NOT NULL,
    CONSTRAINT [fk_teamMember_team_id] FOREIGN KEY([team_id]) REFERENCES [dbo].[Team]([team_id]),
    CONSTRAINT [fk_teamMember_id] FOREIGN KEY([member_id]) REFERENCES [dbo].[Member]([member_id]),
	CONSTRAINT [pk_TeamMember] PRIMARY Key ([team_id], [member_id])
)
GO

print '' print '*** creating Tournament table Garion Opiola'
GO
CREATE TABLE [dbo].[Tournament] 
(
	[tournament_id]		[int] IDENTITY(100000, 1)	NOT NULL,
	[sport_id]			[int]						NOT NULL,
	[gender]			[bit]						NULL,
	[member_id]			[int]						NOT NULL,
	[name]				[nvarchar](250)				NOT NULL,
	[description]		[nvarchar](1000)			NULL,
	[active]			[bit]						NOT NULL
	CONSTRAINT [pk_tournament_id] PRIMARY KEY([tournament_id]),
	CONSTRAINT [fk_Tournament_sport_id] FOREIGN KEY([sport_id])
		REFERENCES [Sport]([sport_id]),
	CONSTRAINT [fk_Tournament_member_id] FOREIGN KEY([member_id])
		REFERENCES [Member]([member_id])
)
GO

print '' print '*** creating venue table Alex Korte'
GO
CREATE TABLE [dbo].[Venue]
(
	[venue_id]		[int] IDENTITY(1000, 1) NOT NULL, 
	[venue_name]	[nvarchar](25),
	[parking]		[nvarchar](250),
	[description]	[nvarchar](2500),
	[location]		[nvarchar](250),
	[zip_code]		[int]					NOT NULL,
	[city]			[nvarchar] (250)		NOT NULL,
	CONSTRAINT [pk_venue_id] PRIMARY KEY ([venue_id])
)
GO

print '' print '*** creating game table Rith'
GO
CREATE TABLE [dbo].[Game] (
	[game_id]				[int] IDENTITY(1000,1)	NOT NULL,
	[venue_id]				[int]					NOT NULL,
	[date_and_time]			[dateTime]				NOT NULL,
	[sport_id]				[int]					NOT NULL,
	[active]				[bit]					NULL	DEFAULT(1),
	CONSTRAINT [pk_game_id] PRIMARY KEY([game_id]),
	CONSTRAINT [fk_venue_id] FOREIGN KEY([venue_id])
		REFERENCES [Venue]([venue_id]),
	CONSTRAINT [fk_sport_id_game_table] FOREIGN KEY([sport_id])
		REFERENCES [Sport]([sport_id])
)
GO

Print '' Print'*** Creating score table Jacob Lindauer ***'
GO
CREATE TABLE [dbo].[Score](
	[team_id]			[int]					NOT NULL,
	[game_id]			[int]					NOT NULL,
	[score]				[decimal](5,2)				NULL
	CONSTRAINT [fk_teamscore_id] FOREIGN KEY ([team_id])
		REFERENCES [Team]([team_id]),
	CONSTRAINT [fk_gamescore_id] FOREIGN KEY ([game_id])
		REFERENCES [Game]([game_id]),
	CONSTRAINT [pk_TeamGameScores] PRIMARY KEY ([team_id], [game_id])
)
GO

print '' print '*** creating Tournament Game table Nick Vroom'
GO
CREATE TABLE [dbo].[TournamentGame] (
	[tournament_id] 	[int] NOT NULL,
	[game_id] 			[int] NOT NULL,
	CONSTRAINT [fk_tournament_id] FOREIGN KEY([tournament_id])
		REFERENCES [Tournament]([tournament_id]),
	CONSTRAINT [fk_TournamentGame_game_id] FOREIGN KEY([game_id])
		REFERENCES [Game]([game_id]),
	CONSTRAINT [pk_TournamentGame] PRIMARY KEY ([tournament_id], [game_id])
)
GO

print '' print '*** creating game roster table Rith'
GO
CREATE TABLE [dbo].[GameRoster] (
	[game_roster_id]			[int] IDENTITY(1000,1)	NOT NULL,
	[team_id]					[int]				NOT NULL,
	[member_id]					[int]				NOT NULL,
	[description]				[nvarchar](250)		NULL,
	[game_id]					[int]				NOT NULL,
	CONSTRAINT [pk_game_roster_id] PRIMARY KEY([game_roster_id]),
	CONSTRAINT [fk_GamePost_game_id] FOREIGN KEY([game_id])
		REFERENCES [Game]([game_id]),
	CONSTRAINT [fk_GamePost_member_id] FOREIGN KEY([member_id])
		REFERENCES [Member]([member_id]),
	CONSTRAINT [fk_team_id] FOREIGN KEY([team_id])
		REFERENCES [Team]([team_id])
)
GO

print "" print "*** create table TeamGame -- Heritier"
GO
CREATE TABLE [dbo].[TeamGame] (
	[team_id]				[int] 							NOT NULL,
    [win]					[bit]							NULL,
	[game_id]				[int]							NOT NULL,
	[game_roster_id]		[int]							NOT NULL,
    CONSTRAINT [fk_pk_team_id] FOREIGN KEY([team_id]) REFERENCES [dbo].[Team]([team_id]),
    CONSTRAINT [fk_game_id] FOREIGN KEY([game_id]) REFERENCES [dbo].[Game]([game_id]),
    CONSTRAINT [fk_game_roster_id] FOREIGN KEY([game_roster_id]) REFERENCES [dbo].[GameRoster]([game_roster_id]),
	CONSTRAINT [pk_TeamGame] PRIMARY KEY ([team_id], [game_id], [game_roster_id])
)
GO

print "" print "*** create table Message table -- Heritier"
GO
CREATE TABLE [dbo].[Message] (
	[message_id]			[int] IDENTITY(1000, 1)			NOT NULL,
    [user_id_sender]		[int]							NOT NULL,
	[user_id_reciever]		[int]							NOT NULL,
	[date_and_time]			[datetime]						NOT NULL,
	[important]				[bit]						  	NOT NULL,
	[message]				[nvarchar](4000)				NOT NULL,
	CONSTRAINT [pk_message_id] PRIMARY KEY([message_id]),
    CONSTRAINT [fk_user_id_sender] FOREIGN KEY([user_id_sender]) REFERENCES [dbo].[Member]([member_id]),
    CONSTRAINT [fk_user_id_reciever] FOREIGN KEY([user_id_reciever]) REFERENCES [dbo].[Member]([member_id])
)
GO

print '' print '*** creating MemberRole table Eli Morgan'
GO
CREATE TABLE [dbo].[MemberRole]
(
	[member_id]		[int]						NOT NULL,
	[role_id]		[nvarchar] (50)				NOT NULL,
	CONSTRAINT [fk_Member_member_id] FOREIGN KEY([member_id])
				REFERENCES [dbo].[Member]([member_id]),
	CONSTRAINT [fk_Role_role_id] FOREIGN KEY([role_id])
				REFERENCES [dbo].[Role]([role_id]) ON UPDATE CASCADE,
	CONSTRAINT [pk_MemberRole] PRIMARY KEY([member_id],[role_id])
)
GO

Print '' Print '*** Creating Table Dues | Jacob Lindauer ***'
GO
CREATE TABLE [dbo].[Dues] (
	[account_id]			[int]		IDENTITY(1000, 1)			NOT NULL,
	[amount]				[money]									NULL,
	[paid]					[bit]									NOT NULL DEFAULT 1,
	[date_and_time]			[datetime]								NOT NULL,
	CONSTRAINT [pk_account_id] PRIMARY KEY ([account_id])
)
GO

print '' print '*** creating League Dues table - Toney Hale'
GO
CREATE TABLE [dbo].[LeagueDues] 
(
	[league_id]			[int] 				NOT NULL,
	[account_id]		[int]				NOT NULL,
	CONSTRAINT 			[fk_LeagueDues_league_id] 
		FOREIGN KEY ([league_id]) REFERENCES [dbo].[League]([league_id]),
	CONSTRAINT 			[fk_LeagueDues_Dues_league_id] 
		FOREIGN KEY ([account_id]) REFERENCES [dbo].[Dues]([account_id]),
	CONSTRAINT			[pk_LeagueDues]
		PRIMARY KEY ([league_id], [account_id])
)
GO

print '' print '*** creating TeamRoleType table Garion Opiola'
GO
CREATE TABLE [dbo].[TeamRoleType] 
(
	[team_role_type_id]			[nvarchar](200)					NOT NULL,
	[team_role_description]		[nvarchar](200)					NULL,
	CONSTRAINT [pk_team_role_type_id] PRIMARY KEY([team_role_type_id])
)
GO

print '' print '*** creating Practice table Nick Vroom'
GO
CREATE TABLE [dbo].[Practice] (
	[practice_id] 	[int] 			IDENTITY(1000,1) NOT NULL,
	[location] 		[nvarchar](250) NOT NULL,
	[team_id]		[int] 			NOT NULL,
	[date_time]		[SMALLDATETIME]	NOT NULL,	
	[description]	[nvarchar](1000) NULL, 
	[zip_code]		[int]					NOT NULL,
	[city]			[nvarchar] (250)		NOT NULL,
	CONSTRAINT [pk_practice_id] PRIMARY KEY([practice_id]),
	CONSTRAINT [fk_Practice_team_id] FOREIGN KEY([team_id])
		REFERENCES [Team]([team_id])
)
GO

print '' print '*** creating Tournament Role table Nick Vroom'
GO
CREATE TABLE [dbo].[TournamentRole] (
	[tournament_role_id] 	[nvarchar](20) 	NOT NULL,
	[description] 			[nvarchar](250) NULL,
	CONSTRAINT [pk_tournament_role_id] PRIMARY KEY([tournament_role_id])
)
GO

print '' print '*** creating gamepost table Rith'
GO
CREATE TABLE [dbo].[GamePost] (
	[game_post_id]				[int] IDENTITY(1000,1)	NOT NULL,
	[game_id]					[int]					NULL,
	[member_id]					[int]					NOT NULL,
	[content]					[nvarchar](1000)		NULL,
	[date_time]					[dateTime]				NOT NULL,
	CONSTRAINT [pk_game_post_id] PRIMARY KEY([game_post_id]),
	CONSTRAINT [fk_Game_Post_game_id] FOREIGN KEY([game_id])
		REFERENCES [Game]([game_id]),
	CONSTRAINT [fk_Game_Post_member_id] FOREIGN KEY([member_id])
		REFERENCES [Member]([member_id])
)
GO

print '' print '*** creating season table Michael Haring ***'
GO
CREATE TABLE [dbo].[season] (
	[season_id]		[int]	IDENTITY(1000, 1),
	[league_id]		[int],
	[description]	[nvarchar](250),
	[sport_id]		[int],
	CONSTRAINT	[pk_season_id]	PRIMARY KEY([season_id]),
	CONSTRAINT	[fk_season_league_id]	FOREIGN KEY([league_id])
					REFERENCES [league]([league_id]),
	CONSTRAINT	[fk_season_sport_id]	FOREIGN KEY([sport_id])
					REFERENCES [sport]([sport_id])
)
GO

print '' print '*** creating seasongame table Michael Haring ***'
GO
CREATE TABLE [dbo].[seasongame] (
	[season_id]		[int],
	[game_id]		[int],
	CONSTRAINT [fk_season_season_id] FOREIGN KEY([season_id])
				REFERENCES [dbo].[season]([season_id]),
	CONSTRAINT [fk_game_game_id] FOREIGN KEY([game_id])
				REFERENCES [dbo].[game]([game_id]),
	CONSTRAINT	[pk_seasongame]	PRIMARY KEY ([season_id], [game_id])
)
GO

print '' print '*** Creating Table Equipment - Brendan'
GO
CREATE TABLE [dbo].[Equipment](
	[equipment_id]			[int] IDENTITY(1000,1) NOT NULL,
	[sport_id]				[int] NOT NULL,
	[description]			[nvarchar](255)	null,
	CONSTRAINT [pk_equipment_id] PRIMARY KEY ([equipment_id]),
	CONSTRAINT	[fk_sports_sports_id_equipment] FOREIGN KEY ([sport_id])
		REFERENCES [dbo].[Sport]([sport_id])
)
GO

Print '' Print '*** Creating Table TeamEquipmentList Gideon***'
GO 
CREATE TABLE [dbo].[TeamEquipmentList] (
	[equipment_id]	[INT]	NOT NULL,
	[team_id]	[INT]	NOT NULL,
	[quantity]	[INT]	NOT NULL DEFAULT 0,
	CONSTRAINT 	[fk_TeamEquipmentList_equipment_id]		FOREIGN KEY ([equipment_id])
	  REFERENCES 	[dbo].[Equipment],
	CONSTRAINT 	[fk_TeamEquipmentList_team_id] 			FOREIGN KEY ([team_id])
	  REFERENCES 	[dbo].[Team],
	CONSTRAINT 	[pk_TeamEquipmentList]		PRIMARY KEY ([equipment_id],[team_id])
)
GO

Print '' Print '*** Creating Table TournamentRoleAssignment Gideon***'
GO 
CREATE TABLE [dbo].[TournamentRoleAssignment] (
	[member_id]		[INT]		NOT NULL,
	[tournament_role_id]	[nvarchar](20)	NOT NULL,
	[tournament_id]		[INT]		NOT NULL,
	CONSTRAINT 		[fk_TournamentRoleAssignment_member_id]			FOREIGN KEY ([member_id])
	  REFERENCES 		[dbo].[Member],
	CONSTRAINT 		[fk_TournamentROleAssignment_tournament_role_id] 	FOREIGN KEY ([tournament_role_id])
	  REFERENCES 		[dbo].[TournamentRole],
	CONSTRAINT 		[fk_TournamentRoleAssignment_tournament_id]		FOREIGN KEY ([tournament_id])
	  REFERENCES 		[dbo].[Tournament],
	CONSTRAINT 		[pk_TournamentRoleAssignment]	PRIMARY KEY ([member_id],[tournament_role_id],[tournament_id])
)
GO

Print '' Print '*** Creating Table TournamentTeam Gideon***'
GO 
CREATE TABLE [dbo].[TournamentTeam] (
	[tournament_id]		[INT]		NOT NULL,
	[team_id]		[INT]		NOT NULL,
	CONSTRAINT 		[fk_tournamentteam_tournament_id]		FOREIGN KEY ([tournament_id])
	  REFERENCES 		[dbo].[Tournament],
	CONSTRAINT 		[fk_tournamentTeam_team_id] 			FOREIGN KEY ([team_id])
	  REFERENCES 		[dbo].[Team],
	CONSTRAINT 		[pk_TournamentTeam]		PRIMARY KEY ([tournament_id],[team_id])
)
GO

print '' print '*** Creating Table Post - Brendan'
GO
create table [dbo].[Post](
	[post_id]		[int]			identity(1000,1)	not null,
	[content]		[nvarchar](1000)					not null,
	[member_id]		[int]								not null,
	[date_and_time]	[datetime]							not null,
	constraint		[pk_post_id]	primary key([post_id]),
	constraint 		[fk_member_member_id_post] FOREIGN KEY ([member_id])
		references[dbo].[Member]([member_id])
)
GO

print '' print '*** creating TournamentDues table Elijah Morgan'
GO
CREATE TABLE [dbo].[TournamentDues]
(
	[tournament_id]		[int]					NOT NULL,
	[account_id]		[int]			 		NOT NULL,
	[due_amount]		[money] 					NULL,
	CONSTRAINT [fk_Tournament_tournament_id] FOREIGN KEY([tournament_id])
				REFERENCES [dbo].[Tournament]([tournament_id]),
	CONSTRAINT [fk_Dues_account_id] FOREIGN KEY([account_id])
				REFERENCES [dbo].[Dues]([account_id]) ON UPDATE CASCADE,
	CONSTRAINT [pk_TournamentAccount] PRIMARY KEY([tournament_id],[account_id])
)
GO

print '' print '*** Creating Table reply - Brendan'
GO
create table[dbo].[Reply](
	[reply_id]		[int]			identity(1000,1)	not null,
	[content]		[nvarchar](1000)					not null,
	[member_id]		[int]								not null,
	[post_id]		[int]								not null,
	[date_and_time]	[datetime]							not null,
	
	constraint		[pk_reply_id]	primary key([reply_id]),
	constraint 		[fk_member_member_id_reply] FOREIGN KEY ([member_id])
		references[dbo].[Member]([member_id]),
	constraint 		[fk_post_post_id_reply] Foreign key ([post_id])
		references[dbo].[Post]([post_id])
);
GO

print '' print '*** creating TeamRole table Garion Opiola'
GO
CREATE TABLE [dbo].[TeamRole] 
(
	[member_id]					[int]	NOT NULL,
	[team_id]					[int]	NOT NULL,
	[team_role_type_id]			[nvarchar] (200) NOT NULL,
	CONSTRAINT [fk_teamRole_member_id] FOREIGN KEY([member_id])
		REFERENCES [dbo].[Member]([member_id]),
	CONSTRAINT [fk_teamRole_team_id] FOREIGN KEY([team_id])
		REFERENCES [dbo].[Team]([team_id]),
	CONSTRAINT [fk_team_role_type_id] FOREIGN KEY([team_role_type_id])
		REFERENCES [dbo].[TeamRoleType]([team_role_type_id]),
	CONSTRAINT [pk_TeamRole] PRIMARY KEY ([member_id], [team_role_type_id])
)
GO

Print '' Print '*** Creating Table Availability | Jacob Lindauer ***'
GO
CREATE TABLE [dbo].[Availability] (
	[availability_id]		[int]			IDENTITY(1000, 1) 		NOT NULL, 
	[description]			[nvarchar](250)							NULL,
	[member_id]				[int]									NOT NULL,
	[start_availability]	[datetime]								NOT NULL,
	[end_availability]		[datetime]								NOT NULL,
	CONSTRAINT	[fk_Availability_User]
		FOREIGN KEY ([member_id]) REFERENCES [dbo].[Member]([member_id]),
	CONSTRAINT	[pk_availability_id]
		PRIMARY KEY ([availability_id])
)	
GO

print '' print '*** creating VenueEquipmentList table Alex Korte'
GO
CREATE TABLE [dbo].[VenueEquipmentList]
(
	[equipment_id]				[int] NOT NULL,
	[venue_id]					[int] NOT NULL,
	[quantity]					[int] NOT NULL DEFAULT 0,
	CONSTRAINT [fk_VenueEquiptmentList_venue_id]
		FOREIGN KEY ([venue_id]) REFERENCES [dbo].[Venue]([venue_id]),
	CONSTRAINT [fk_VenueEquiptmentList_equipment_id]
		FOREIGN KEY ([equipment_id]) REFERENCES [dbo].[Equipment]([equipment_id]),
	CONSTRAINT [pk_VenueEquipmentList_id] PRIMARY KEY ([equipment_id], [venue_id])
)
GO

print '' print '*** creating VolunteerNeeded table Alex Korte'
GO
CREATE TABLE [dbo].[VolunteerNeeded]
(
	[volunteer_needed_id]		[int] IDENTITY (1000, 1) NOT NULL,
	[game_id]					[int] NOT NULL,
	[description] 				[nvarchar] (250) NOT NULL,
	[quantity]					[int] NOT NULL DEFAULT 0,
	CONSTRAINT [fk_VolunteerNeeded_game_id]
		FOREIGN KEY ([game_id]) REFERENCES [dbo].[Game]([game_id]),
	CONSTRAINT [pk_volunteer_needed_id] PRIMARY KEY ([volunteer_needed_id])
)
GO

print '' print '*** creating VolunteerSignUp table Alex Korte'
GO

CREATE TABLE [dbo].[VolunteerSignUp]
(
	[volunteer_needed_id]		[int] NOT NULL,
	[member_id]					[int] NOT NULL,
	CONSTRAINT [fk_VoluneteerSignUp_volunteer_needed_id]
		FOREIGN KEY ([volunteer_needed_id]) REFERENCES [dbo].[VolunteerNeeded]([volunteer_needed_id]),
	CONSTRAINT [fk_VolunteerSignUP_member_id]
		FOREIGN KEY ([member_id]) REFERENCES [dbo].[Member]([member_id])
)
GO 

print '' print '*** creating zipcode TABLE'
GO

CREATE TABLE [dbo].[zipcode]
(
	[zip_code]  [int] NOT NULL,
	[city]		[nvarchar] (256) NOT NULL,
	[st]		[VARCHAR] (2) NOT NULL,
	CONSTRAINT [pk_zip_code] PRIMARY KEY ([zip_code])
)
GO