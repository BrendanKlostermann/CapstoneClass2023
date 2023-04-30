print "" print "*** using database ecgo_db to create SAMPLE DATA"
GO
USE [ecgo_db]
GO

print ''print 'sample member table'
INSERT INTO [dbo].[Member] ([email], [first_name], [family_name], [birthday], [phone_number], [passwordHash], [gender], [active], [bio], [profile_photo], [PhotoMimeType])
VALUES
('john@example.com', 'John', 'Doe', '1990-01-01', '555-1234', '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 1, 1, 'I love hiking and camping.', NULL, NULL),
('jane@example.com', 'Jane', 'Doe', '1992-05-12', NULL, '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 0, 1, NULL, NULL, NULL),
('bill@example.com', 'Bill', 'Smith', '1985-12-01', '555-5678', '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 1, 1, 'I am a professional chef.', NULL, NULL),
('jim@example.com', 'Jim', 'Johnson', '1998-09-24', NULL, '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 1, 1, NULL, NULL, NULL),
('susan@example.com', 'Susan', 'Lee', '1982-07-18', '555-2468', '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 0, 1, 'I am a software engineer.', NULL, NULL),
('fred@example.com', 'Fred', 'Davis', '1975-03-08', '555-7890', '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 1, 1, 'I am an artist.', NULL, NULL),
('mary@example.com', 'Mary', 'Wilson', '1995-11-03', NULL, '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 0, 1, NULL, NULL, NULL),
('tom@example.com', 'Tom', 'Brown', '1988-02-16', '555-1010', '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 1, 1, 'I am a teacher.', NULL, NULL),
('lisa@example.com', 'Lisa', 'Anderson', '1993-06-22', NULL, '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 0, 1, 'I am a student.', NULL, NULL),
('steve@example.com', 'Steve', 'Wilson', '1980-12-10', '555-4444', '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 1, 1, 'I am a lawyer.', NULL, NULL),
('amy@example.com', 'Amy', 'Johnson', '1987-03-18', NULL, '9C9064C59F1FFA2E174EE754D2979BE80DD30DB552EC03E7E327E9B1A4BD594E', 0, 1, NULL, NULL, NULL);
GO

print ''print 'sample adminrole table'
INSERT INTO [dbo].[AdminRole] ([admin_role_id], [admin_role_type])
VALUES
('Super Admin', 'Super Admin'),
('Admin', 'Admin'),
('Editor', 'Editor'),
('Moderator', 'Moderator'),
('Support', 'Support'),
('Developer', 'Developer'),
('Tester', 'Tester'),
('Analyst', 'Analyst'),
('Manager', 'Manager'),
('Designer', 'Designer');
GO

print ''print 'sample role table'
INSERT INTO [dbo].[Role] ([role_id], [description])
VALUES
(N'Admin', N'Admin'),
(N'Score Reporter', N'Score Reporter'),
(N'Player', N'Player'),
(N'Coach', N'Coach'),
(N'Assistant Coach', N'Assistant Coach'),
(N'Team Captain', N'Team Captain'),
(N'Logistics', N'Logistics'),
(N'Moderators', N'Moderators'),
(N'Volunteers', N'Volunteers'),
(N'Commentator', N'Commentator'),
(N'Referee', N'Referee'),
(N'Tournament Admin', N'Tournament Admin'),
(N'League Admin', N'League Admin'),
(N'Treasurer', N'Treasurer'),
(N'Recruiter', N'Recruiter'),
(N'Equipment Manager', N'Equipment Manager'),
(N'Vendor', N'Vendor'),
(N'Venue Rep', N'Venue Rep'),
(N'Videographer', N'Videographer'),
(N'Spectator', N'Spectator'),
(N'Potential Player', N'Potential Player')
GO


print ''print 'sample leagueroles table'
INSERT INTO [dbo].[LeagueRole] ([league_role_id], [description])
VALUES
('League Admin', 'League Admin'),
('League Manager', 'League Manager'),
('Team Captain', 'Team Captain'),
('Player', 'Player'),
('Spectator', 'Spectator');
GO

print ''print 'sample sport table'
INSERT INTO [dbo].[Sport] ([description])
VALUES
('Football'),
('Basketball'),
('Tennis'),
('Baseball'),
('Volleyball'),
('Soccer'),
('Hockey'),
('Golf'),
('Swimming'),
('Track and Field');
GO


print ''print 'sample league table'
INSERT INTO [dbo].[League] ([sport_id], [league_dues], [active], [member_id], [gender], [description], [name], [max_num_of_teams])
VALUES
(1000, 50.00, 1, 100001, 1, 'This is a co-ed league for all skill levels.', 'Co-ed Football League', 12),
(1002, 40.00, 0, 100003, 1, 'This is a men''s basketball league for intermediate players.', 'Intermediate Men''s Basketball League', 10),
(1003, 25.00, 1, 100002, 0, 'This is a women-only tennis league for advanced players.', 'Advanced Women''s Tennis League', 8),
(1004, NULL, 1, 100004, NULL, 'This is a mixed baseball league for all ages.', 'Mixed Baseball League', NULL),
(1005, 20.00, 1, 100006, NULL, 'This is a community volleyball league for all ages and skill levels.', 'Community Volleyball League', 8),
(1006, 30.00, 1, 100005, 0, 'This is a recreational soccer league for all ages and skill levels.', 'Recreational Soccer League', 16),
(1007, 60.00, 1, 100007, 1, 'This is a competitive ice hockey league for experienced players.', 'Competitive Men''s Ice Hockey League', 6),
(1008, 10.00, 1, 100008, 0, 'This is a casual golf league for all ages and skill levels.', 'Casual Golf League', 20),
(1009, 35.00, 1, 100010, 1, 'This is a Masters swimming league for swimmers aged 30 and over.', 'Masters Swimming League', 4);
GO


print ''print 'sample leagueRoleAssignment table'
INSERT INTO [dbo].[LeagueRoleAssignment] ([member_id], [league_role_id], [league_id])
VALUES
(100001, 'League Admin', 1000),
(100002, 'Player', 1002),
(100003, 'Spectator', 1003),
(100004, 'Player', 1001),
(100005, 'League Manager', 1002);
GO

print ''print 'sample team table'
INSERT INTO [dbo].[Team] ([team_name], [active], [gender], [sport_id], [member_id], [description])
VALUES
('Redhawks', 1, 1, 1000, 100001, 'This is a co-ed football team.'),
('Cougars', 1, 0, 1002, 100002, 'This is a women''s basketball team.'),
('Tigers', 1, 1, 1003, 100003, 'This is a men''s tennis team.'),
('Bulldogs', 1, 1, 1004, 100004, 'This is a mixed baseball team.'),
('Hawks', 0, NULL, 1005, 100005, 'This is a community volleyball team.'),
('Panthers', 1, 1, 1000, 100006, 'This is a men''s football team.'),
('Lions', 1, 0, 1002, 100007, 'This is a women''s basketball team.'),
('Eagles', 1, 1, 1003, 100008, 'This is a men''s tennis team.'),
('Bears', 1, 1, 1004, 100009, 'This is a mixed baseball team.');
GO


print ''print 'sample league team table'
INSERT INTO [dbo].[LeagueTeam] ([league_id], [team_id])
VALUES 
(1000, 1000),
(1000, 1001),
(1000, 1002),
(1000, 1003),
(1001, 1004),
(1001, 1005),
(1001, 1006),
(1002, 1007),
(1002, 1008);
GO

print ''print 'sample team member table'
INSERT INTO [dbo].[TeamMember] ([team_id], [description], [starter], [member_id])
VALUES
(1000, 'Starting member', 1, 100001),
(1000, 'Backup', 0, 100006),
(1000, 'Backup member', 0, 100002),
(1000, 'Backup member', 0, 100003),
(1001, 'Starting member', 1, 100004),
(1001, 'Backup member', 0, 100005),
(1001, 'Backup member', 0, 100006),
(1002, 'Starting member', 1, 100007),
(1002, 'Starting lineup', 1, 100002),
(1002, 'Backup member', 0, 100008),
(1002, 'Backup member', 0, 100009),
(1003, 'Starting lineup', 1, 100003),
(1003, 'Backup', 0, 100008),
(1004, 'Starting lineup', 1, 100004),
(1004, 'Backup', 0, 100009),
(1005, 'Starting lineup', 1, 100005);
GO

print ''print 'sample tournament table'
INSERT INTO [dbo].[Tournament] ([sport_id], [gender], [member_id], [name], [description], [active])
VALUES
(1000, 1, 100000, 'Co-ed Football Tournament', 'This is a tournament for all skill levels.', 1),
(1003, 0, 100002, 'Women''s Baseball Tournament', 'This is a tournament for advanced players.', 1),
(1002, 1, 100003, 'Men''s Basketball Tournament', 'This is a tournament for intermediate players.', 0),
(1004, NULL, 100004, 'Mixed Volleyball Tournament', 'This is a tournament for all ages.', 1),
(1006, 0, 100005, 'Women''s Hockey Tournament', 'This is a tournament for all ages and skill levels.', 1),
(1005, NULL, 100006, 'Community Soccer Tournament', 'This is a tournament for all ages and skill levels.', 1),
(1007, 1, 100007, 'Competitive Men''s Golf Tournament', 'This is a tournament for experienced players.', 1),
(1008, 0, 100008, 'Women''s Swimming Tournament', 'This is a tournament for all ages and skill levels.', 1),
(1009, 1, 100001, 'Track and Field Tournament', 'This is a tournament for track and field.', 1);
GO

print ''print 'sample venue table'
INSERT INTO [dbo].[Venue] ([venue_name], [parking], [description], [location], [zip_code], [city])
VALUES
('ABC Stadium', 'Free parking available in adjacent lot.', 'A large outdoor stadium.', '123 Main St', 90210, 'Los Angeles'),
('XYZ Arena', 'Parking available for $10 in nearby garage.', 'A smaller indoor arena.', '456 Broad St', 60601, 'Chicago'),
('Community Center two', 'Parking available on site.', 'A multipurpose indoor facility.', '789 Oak Ave', 10001, 'New York'),
('Community Center', 'Parking available on site.', 'A multipurpose indoor facility.', '789 Oak Ave', 10001, 'New York');
GO



print ''print 'sample game table'
INSERT INTO [dbo].[Game] ([venue_id], [date_and_time], [sport_id], [member_id])
VALUES 
(1000, '2023-03-25 14:00:00', 1000, 100001),
(1001, '2023-03-26 10:00:00', 1001, 100002),
(1002, '2023-03-27 15:00:00', 1002, 100003),
(1000, '2023-03-28 12:00:00', 1003, 100004),
(1001, '2023-03-29 11:00:00', 1004, 100005),
(1002, '2023-03-30 14:00:00', 1005, 100006),
(1000, '2023-04-01 09:00:00', 1006, 100007),
(1001, '2023-04-02 16:00:00', 1007, 100008),
(1002, '2023-04-03 10:00:00', 1008, 100009);
GO

print ''print 'sample score table'
INSERT INTO [dbo].[Score] ([team_id], [game_id], [score])
VALUES
(1000, 1000, 21.50),
(1001, 1000, 14.75),
(1002, 1001, 28.00),
(1003, 1001, 21.50)
GO


print ''print 'sample score table'
INSERT INTO [dbo].[TournamentGame] ([tournament_id], [game_id])
VALUES
(100000, 1000),
(100000, 1001),
(100001, 1002),
(100001, 1003),
(100002, 1004),
(100002, 1005);
GO


 print ''print 'sample gameRoster table'
INSERT INTO [dbo].[GameRoster] ([team_id], [member_id], [description], [game_id])
VALUES
(1000, 100001, 'Starting Quarterback/Safety', 1000),
(1000, 100002, 'Starting Wide Reciever/Cornerback', 1000),
(1000, 100003, 'Starting Runningback/Linebacker', 1000),
(1000, 100004, 'Starting Wide Reciever 2 / Cornerback 2', 1000),
(1001, 100005, 'Starting Quarterback/Safety', 1000),
(1001, 100006, 'Starting Wide Reciever/Cornerback', 1000),
(1001, 100007, 'Starting Runningback/Linebacker', 1000),
(1001, 100008, 'Starting Wide Reciever 2 / Cornerback 2', 1000),
(1002, 100001, 'Starting Quarterback/Safety', 1001),
(1002, 100002, 'Starting Wide Reciever/Cornerback', 1001),
(1002, 100003, 'Starting Runningback/Linebacker', 1001),
(1002, 100004, 'Starting Wide Reciever 2 / Cornerback 2', 1001),
(1003, 100005, 'Starting Quarterback/Safety', 1001),
(1003, 100006, 'Starting Wide Reciever/Cornerback', 1001),
(1003, 100007, 'Starting Runningback/Linebacker', 1001),
(1003, 100008, 'Starting Wide Reciever 2 / Cornerback 2', 1001);
GO 


print ''print 'sample teamGame table'
INSERT INTO [dbo].[TeamGame] ([team_id], [win], [game_id], [game_roster_id])
VALUES
(1000, 1, 1000, 1000),
(1002, 0, 1000, 1001),
(1001, 1, 1001, 1002),
(1003, 0, 1001, 1003),
(1004, 1, 1002, 1004),
(1006, 0, 1002, 1005);
GO



print '' print 'sample MemberRole table'
INSERT INTO [dbo].[MemberRole] ([member_id], [role_id])
VALUES
(100001, 'Player'),
(100001, 'Assistant Coach'),
(100002, 'Admin'),
(100002, 'Assistant Coach'),
(100003, 'Assistant Coach'),
(100004, 'Assistant Coach'),
(100005, 'Coach'),
(100006, 'Coach'),
(100007, 'Coach'),
(100008, 'Coach'),
(100009, 'Coach'),
(100010, 'Coach');
GO

print '' print 'sample Message table'
INSERT INTO [dbo].[Message] ([user_id_sender], [user_id_reciever], [date_and_time], [important], [message])
VALUES 
(100001, 100002, '2022-03-22 09:30:00', 1, 'Hey, are you coming to the game tonight?'),
(100002, 100001, '2022-03-22 10:15:00', 0, 'Sorry, I cant make it tonight. Maybe next time.'),
(100003, 100004, '2022-03-22 11:00:00', 1, 'Reminder: Practice is at 5pm today.'),
(100004, 100003, '2022-03-22 11:30:00', 0, 'Thanks for letting me know.'),
(100005, 100001, '2022-03-22 12:00:00', 1, 'Do you need a ride to the game tonight?'),
(100001, 100005, '2022-03-22 12:15:00', 0, 'Yes, that would be great. What time should I be ready?');
GO


print '' print 'sample Dues table'
INSERT INTO [dbo].[Dues] ([amount], [paid], [date_and_time])
VALUES 
(50.00, 1, '2022-01-01 09:00:00'),
(25.00, 0, '2022-02-01 09:00:00'),
(40.00, 1, '2022-03-01 09:00:00'),
(30.00, 1, '2022-04-01 09:00:00'),
(20.00, 0, '2022-05-01 09:00:00'),
(60.00, 1, '2022-06-01 09:00:00'),
(10.00, 1, '2022-07-01 09:00:00'),
(35.00, 0, '2022-08-01 09:00:00'),
(45.00, 1, '2022-09-01 09:00:00'),
(15.00, 1, '2022-10-01 09:00:00');
GO


print '' print 'sample LeagueDues table'
INSERT INTO [dbo].[LeagueDues] ([league_id], [account_id])
VALUES
(1000, 1000),
(1000, 1001),
(1001, 1002),
(1001, 1003),
(1002, 1004),
(1002, 1005),
(1003, 1006),
(1003, 1007),
(1004, 1008),
(1004, 1009);
GO

print '' print 'sample teamrole type table'
INSERT INTO [dbo].[TeamRoleType] ([team_role_type_id], [team_role_description])
VALUES 
('player', 'Player'),
('coach', 'Coach'),
('assistant_coach', 'Assistant Coach'),
('team_manager', 'Team Manager');
GO


print '' print 'sample practice table'
INSERT INTO [dbo].[Practice] ([location], [team_id], [date_time], [description], [zip_code], [city])
VALUES
('Central Park', 1000, '2023-03-28 18:00:00', 'Outdoor practice', 10001, 'New York'),
('Stadium', 1002, '2023-04-01 20:00:00', 'Practice for upcoming game', 50021, 'Chicago'),
('Community Center', 1001, '2023-03-29 16:00:00', NULL, 90001, 'Los Angeles'),
('Gymnasium', 1005, '2023-03-31 18:00:00', 'Indoor practice', 20002, 'Washington DC'),
('Field', 1003, '2023-04-02 10:00:00', 'Practice drills', 77001, 'Houston'),
('School Playground', 1004, '2023-03-30 14:00:00', 'Practice before the tournament', 60001, 'New Jersey');
GO

print '' print 'sample tournamentRole table'
INSERT INTO [dbo].[TournamentRole] ([tournament_role_id], [description])
VALUES 
('manager', 'Responsible for managing the tournament'),
('official', 'Officiates games during the tournament'),
('player', 'Competes in the tournament as a player');
GO


print '' print 'sample gamePost table'
INSERT INTO [dbo].[GamePost] ([game_id], [member_id], [content], [date_time])
VALUES
(1001, 100003, 'Excited for the upcoming match!', '2022-01-01 10:00:00'),
(1002, 100004, 'Can''t wait to hit some home runs!', '2022-01-02 14:30:00'),
(1003, 100006, 'We are gonna crush the competition!', '2022-01-03 16:00:00'),
(1004, 100007, 'Let us bring home the victory!', '2022-01-04 09:00:00'),
(1005, 100009, 'We haveve been practicing hard for this game. Let''s win it!', '2022-01-05 12:00:00'),
(1006, 100002, 'Good luck to all the teams competing today!', '2022-01-06 08:00:00'),
(1007, 100008, 'Let us show them what we''re made of!', '2022-01-07 15:00:00'),
(1007, 100005, 'We are ready to spike our way to victory!', '2022-01-08 11:00:00');
GO


print '' print 'sample season table'
INSERT INTO [dbo].[season] ([league_id], [description], [sport_id]) 
VALUES 
(1000, '2023 Season', 1000),
(1001, '2023 Season', 1001),
(1002, '2023 Season', 1002),
(1003, '2023 Season', 1003),
(1004, '2023 Season', 1004);
GO




print '' print 'sample seasongame table'
INSERT INTO [dbo].[seasongame] ([season_id], [game_id])
VALUES 
(1000, 1000),
(1000, 1001),
(1001, 1002),
(1001, 1003),
(1002, 1004),
(1002, 1005),
(1003, 1006),
(1003, 1007);
GO



print '' print 'sample equipment table'
INSERT INTO [dbo].[Equipment] ([sport_id], [description])
VALUES 
(1001, 'Football'),
(1002, 'Basketball'),
(1003, 'Tennis'),
(1004, 'Baseball'),
(1005, 'Volleyball');
GO


print '' print 'sample teamEquipmentList table'
INSERT INTO [dbo].[TeamEquipmentList] ([equipment_id], [team_id], [quantity])
VALUES 
(1000, 1000, 10),
(1002, 1001, 5),
(1003, 1002, 20),
(1004, 1002, 15),
(1004, 1003, 8),
(1002, 1004, 12),
(1000, 1004, 6);
GO


print '' print 'sample tournamentroleAssignment table'
INSERT INTO [dbo].[TournamentRoleAssignment] ([member_id], [tournament_role_id], [tournament_id])
VALUES 
(100001, 'manager', 100000),
(100002, 'official', 100000),
(100003, 'player', 100000),
(100004, 'manager', 100001),
(100005, 'official', 100001),
(100006, 'player', 100001);
GO

print '' print 'sample tournamentTeam table'
INSERT INTO [dbo].[TournamentTeam] ([tournament_id], [team_id])
VALUES
(100000, 1000),
(100000, 1001),
(100001, 1002),
(100001, 1003),
(100001, 1004),
(100001, 1007),
(100002, 1005),
(100002, 1007),
(100003, 1002),
(100003, 1003),
(100004, 1006),
(100004, 1000),
(100005, 1006),
(100005, 1000),
(100006, 1004),
(100006, 1000),
(100007, 1008),
(100007, 1001),
(100008, 1008),
(100008, 1005)
GO



print '' print 'sample Post table'
INSERT INTO [dbo].[Post] ([content], [member_id], [date_and_time])
VALUES 
('Hello world!', 100001, '2022-03-21 14:30:00'),
('This is a test post.', 100002, '2022-03-21 16:45:00'),
('Check out this awesome article!', 100003, '2022-03-22 09:15:00'),
('I need help with my project.', 100004, '2022-03-22 14:00:00');
GO


print '' print 'sample tournamentDues table'
INSERT INTO [dbo].[TournamentDues] ([tournament_id], [account_id], [due_amount])
VALUES 
(100000, 1000, 50.00),
(100000, 1001, 75.00),
(100001, 1002, 100.00),
(100001, 1003, 125.00),
(100002, 1004, 150.00);
GO


print '' print 'sample post reply table'
INSERT INTO [dbo].[Reply] ([content], [member_id], [post_id], [date_and_time])
VALUES 
('Great post, thanks for sharing!', 100003, 1000, '2022-03-20 13:30:00'),
('I totally agree with your points!', 100002, 1001, '2022-03-20 14:15:00'),
('Interesting perspective, I never thought of it that way.', 100001, 1002, '2022-03-21 10:00:00'),
('Thanks for the helpful tips!', 100000, 1002, '2022-03-21 11:30:00'),
('I have a question, could you clarify this point?', 100004, 1003, '2022-03-22 09:45:00');
GO

print '' print 'sample team roles table'
INSERT INTO [dbo].[TeamRole] ([member_id], [team_id], [team_role_type_id])
VALUES 
(100001, 1001, 'coach'),
(100002, 1001, 'Player'),
(100003, 1002, 'coach'),
(100004, 1002, 'Player');
GO


print '' print 'sample availability table'
INSERT INTO [dbo].[Availability] ([description], [member_id], [start_availability], [end_availability])
VALUES 
('Available all day', 100001, '2022-01-01 00:00:00', '2022-01-01 23:59:59'),
('Available in the afternoon', 100002, '2022-01-02 12:00:00', '2022-01-02 18:00:00'),
('Available in the morning', 100003, '2022-01-03 06:00:00', '2022-01-03 12:00:00'),
('Available in the evening', 100004, '2022-01-04 18:00:00', '2022-01-04 23:59:59');
GO


print '' print 'sample venue equipment table'
INSERT INTO [dbo].[VenueEquipmentList] ([equipment_id], [venue_id], [quantity])
VALUES 
(1001, 1001, 10),
(1001, 1002, 5),
(1002, 1003, 8),
(1002, 1002, 3),
(1002, 1001, 2),
(1003, 1001, 5),
(1003, 1003, 10),
(1004, 1001, 7),
(1004, 1002, 4),
(1004, 1003, 1);
GO

print '' print 'sample volunteerNeeded table'
INSERT INTO [dbo].[VolunteerNeeded] ([game_id], [description], [quantity])
VALUES 
(1001, 'Concession Stand', 3),
(1001, 'Score Keeper', 2),
(1002, 'Concession Stand', 2),
(1002, 'Ticket Sales', 2);
GO

print '' print 'sample volunteerSignUp table'
INSERT INTO [dbo].[VolunteerSignUp] ([volunteer_needed_id], [member_id])
VALUES 
(1000, 100001), 
(1001, 100002), 
(1002, 100003),
(1000, 100004),
(1001, 100005),
(1003, 100006),
(1002, 100007);
GO

print '' print 'Sample TeamRequests table'
INSERT INTO [dbo].[TeamRequest]
([member_id], [team_id], [status])
VALUES
(100000, 1000, "Waiting"),
(100002, 1000, "Accepted"),
(100003, 1000, "Waiting"),
(100004, 1000, "Waiting"),
(100005, 1000, "Waiting"),
(100006, 1000, "Waiting"),
(100007, 1000, "Waiting"),
(100008, 1000, "Waiting"),
(100009, 1000, "Waiting"),
(100010, 1000, "Waiting")
GO



