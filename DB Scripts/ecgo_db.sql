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