BEGIN
	INSERT INTO tblPost(Id, UserId, BookId, ConditionId, Description, Price)
	VALUES
	(1, 1, 1, 1, 'Yes', 10),
	(2, 2, 2, 2, 'No', 20),
	(3, 3, 3, 3, 'Maybe', 30)
END