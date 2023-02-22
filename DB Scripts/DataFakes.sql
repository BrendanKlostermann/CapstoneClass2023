print '' print '*** creating member fakes -Alex Korte'
GO

USE [ecgo_db]
GO

INSERT INTO [dbo].[Member]
(
	[email],
	[first_name],	
	[family_name],
	[birthday],	
	[phone_number],
	[gender],
	[active],		
	[bio]			
)
VALUES
("1@gmail.com", "1", "One", '1980-11-04', "5159758769", 1, 1, "Test Profile"),
("2@gmail.com", "2", "Two", '1980-11-04', "5159758769", 1, 1, "Test Profile for Crackers"),
("3@gmail.com", "3", "Three", '1978-10-02', "5159758769", 2, 1, "Test Profile for Water"),
("4@gmail.com", " 4", "Four", '1999-02-03', "5159758769", 2, 1, "Test Profile for Pen"),
("5@gmail.com", " 5", "Five", '1996-02-03', "5159758769", 2, 1, "Test Profile for Remote"),
("6@gmail.com", "6", "Six", '1980-11-04', "5159758769", 1, 1, "Test Profile"),
("7@gmail.com", "7", "Seven", '1980-11-04', "5159758769", 1, 1, "Test Profile for Crackers"),
("8@gmail.com", "8", "Eight", '1978-10-02', "5159758769", 2, 1, "Test Profile for Water"),
("9@gmail.com", " 9", "Nine", '1999-02-03', "5159758769", 2, 1, "Test Profile for Pen"),
("10@gmail.com", " 10", "Ten", '1996-02-03', "5159758769", 2, 1, "Test Profile for Remote"),
("11@gmail.com", "11", "Eleven", '1980-11-04', "5159758769", 1, 1, "Test Profile"),
("12@gmail.com", "12", "Twelve", '1980-11-04', "5159758769", 1, 1, "Test Profile for Crackers"),
("13@gmail.com", "13", "Thirteen", '1978-10-02', "5159758769", 2, 1, "Test Profile for Water"),
("14@gmail.com", " 14", "Fourteen", '1999-02-03', "5159758769", 2, 1, "Test Profile for Pen"),
("15@gmail.com", " 15", "Fifteen", '1996-02-03', "5159758769", 2, 1, "Test Profile for Remote")
GO

print '' print '*** creating sport fakes -Alex Korte'
GO
INSERT INTO [dbo].[Sport]
(
	[description]
)
VALUES
("Soccer"),
("Football"),
("Magic the Gathering")
GO

print '' print '*** creating fake team -Alex Korte'
GO
INSERT INTO [dbo].[Team]
(
	[team_name],
	[gender],
	[sport_id]
)
VALUES
("Test Team", 1, 1000),
("football team 2", 1, 1001),
("magoic team 3", 1, 1002)
GO

print '' print '*** creating fake team members -Alex Korte'
GO
INSERT INTO [dbo].[TeamMember]
(
	[team_id],
	[description],
	[starter],
	[member_id]
)
VALUES
(1000, "testing soccer team", 1, 100000),
(1000, "testing soccer team", 0, 100001),
(1000, "testing soccer team", 1, 100002),
(1000, "testing soccer team", 0, 100003),
(1000, "testing soccer team", 1, 100004),
(1000, "testing soccer team", 0, 100005),
(1000, "testing soccer team", 1, 100006),
(1000, "testing soccer team", 0, 100007),
(1000, "testing soccer team", 1, 100008),
(1000, "testing soccer team", 0, 100009),
(1000, "testing soccer team", 1, 100010),
(1000, "testing soccer team", 0, 100011),
(1000, "testing soccer team", 1, 100012),
(1000, "testing soccer team", 0, 100013),
(1000, "testing soccer team", 1, 100014)
GO

