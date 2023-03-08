/* Sport records */
print '' print '*** adding sample Sport record ***'
GO
INSERT INTO [dbo].[Sport]
	([description])
	VALUES
		('Football'),
		('Soccer'),
		('Magic the Gathering')
GO

/* Member records */
print '' print '*** adding sample Member record ***'
GO
INSERT INTO [dbo].[Member]
	([email], [first_name], [family_name], [birthday], [phone_number], 
		[gender], [active], [bio])
	VALUES
		('marybeth@gmail.com', 'Mary', 'Beth', '1998-11-11', '(843) 128-9285', 1, 1, 'A gal'),
		('richevans@gmail.com', 'Rich', 'Evans', '1989-05-03', '(835) 835-8354', 0, 0, 'A guy'),
		('mikecostanza@gmail.com', 'Mike', 'Costanza', '1985-09-28', '(527) 836-2743', 0, 0, 'Another guy'),
		('elijahmorgan@gmail.com', 'Elijah', 'Morgan', '2002-03-13', '(276) 692-6592', 0, 1, 'Another other guy')
GO


/* League records */
print '' print '*** adding sample League record ***'
GO
INSERT INTO [dbo].[League]
	([sport_id], [league_dues], [active], [member_id], 
		[gender], [description], [name])
	VALUES
		(1000, 100000.00, 0, 100000, 0, 'A football league.', "Football League #1"),
		(1000, 46.72, 1, 100001, 1, 'Another football league.', "Football League #2"),
		(1001, 1034.70, 0, 100002, 0, 'A soccer league.', "Awesome Soccer League"),
		(1002, 0.00, 1, 100003, NULL, 'A MTG league.', "Magic the Gathering League")
GO