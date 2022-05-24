IF not exists (SELECT 1 FROM dbo.[User])

BEGIN
	insert into dbo.[User] (FirstName,LastName)
	VALUES ('Marcin', 'Rakoczy'),
	('Stefan', 'Śliwka'),
	('Jola','Gruszka'),
	('Adam', 'Pomelo')
END