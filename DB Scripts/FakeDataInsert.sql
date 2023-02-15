use [ecgo_db]
GO

print'' print'Inserting into Member table'
GO

INSERT INTO [dbo].[Member]
			([email],[first_name],[family_name],[birthday],[phone_number])
		VALUES
			('asmith@ecgo.com', 'Adam', 'Smith', '1999-03-29', '319-480-1234'),
			('bsmith@ecgo.com', 'Brian', 'Smith', '1998-02-28', '319-480-4567'),
			('csmith@ecgo.com', 'Charles', 'Smith', '1997-01-27', '319-480-8901'),
			('dsmith@ecgo.com', 'Doug', 'Smith', '1996-12-26', '319-480-2345'),
			('esmith@ecgo.com', 'Edward', 'Smith', '1995-11-25', '319-480-5678'),
			('fsmith@ecgo.com', 'Frank', 'Smith', '1994-10-24', '319-480-6789')
GO

print '' print '** Inserting into the Sport Table ***'
GO
INSERT INTO [dbo].[Sport]
			([description])
		VALUES
			('Pong'),
			('Flippy Cup'),
			('Spoons'),
			('Go Fish')
GO

print '' print '*** Inserting into Team Table ***'
GO
INSERT INTO [dbo].[Team]
			([team_name], [gender], [sport_id])
		VALUES
			('TheBestTeam', 1, 1001),
			('TheWorstTeam', 0, 1001),
			('TheMediocreTeam', null, 1002),
			('TheOkayTeam', 1, 1002)
GO

print '' print '*** Inserting into Venue Table ***'
GO
INSERT INTO [dbo].[Venue]
			([venue_name], [parking], [description], [location], [zip_code], [city])
		VALUES
			('The Sports Arena', 'Park in rear', 'The Best Spot for Sports', '15234 Gravel Rd', '52402', 'Monticello'),
			('Public Field', 'Anywhere in Lot', 'Call Ahead to Schedule Reservation', '1234 Eagle Lane',  '52302', 'Marion'),
			('Computer Cafe', 'Street', '$12 for computer or BYOD', '1251 Main St SW' ,'52401', 'Cedar Rapids'),
			('Toms Place', 'Wherever Available, NOT THE OLD LADY`S SIDE OF STREET', 'Free Drinks', '123 Lazy BLVD', '52102', 'Waterloo')
GO			

print '' print '** Inserting Into Game Table ***'
GO
INSERT INTO [dbo].[Game]
		([score], [venue_id], [date_and_time])
	VALUES 
		(0, 1000, '2023-02-04'),
		(0, 1003, '2023-01-02'),
		(0, 1002, '2023-06-03'),
		(0, 1001, '2023-03-29')
GO

print '' print '*** Insert Into GameRoster Table ***'
GO
INSERT INTO [dbo].[GameRoster]
			([team_id], [member_id], [description], [game_id])
		VALUES
			(1000, 100000, 'Home Team', 1000),
			(1000, 100001, 'Home Team', 1000),
			(1000, 100002, 'Home Team', 1000),
			(1001, 100003, 'Away Team', 1000),
			(1001, 100004, 'Away Team', 1000),
			(1001, 100005, 'Away Team', 1000),
			(1003, 100000, 'Home Team', 1001),
			(1003, 100001, 'Home Team', 1001),
			(1003, 100002, 'Home Team', 1001),
			(1000, 100003, 'Away Team', 1001),
			(1000, 100004, 'Away Team', 1001),
			(1000, 100005, 'Away Team', 1001),
			(1002, 100000, 'Home Team', 1002),
			(1002, 100001, 'Home Team', 1002),
			(1002, 100002, 'Home Team', 1002),
			(1000, 100003, 'Away Team', 1002),
			(1000, 100004, 'Away Team', 1002),
			(1000, 100005, 'Away Team', 1002)
GO