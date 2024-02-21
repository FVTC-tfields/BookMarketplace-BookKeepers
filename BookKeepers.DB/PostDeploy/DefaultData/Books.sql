BEGIN
	INSERT INTO tblBook(Id, AuthorId, PublisherId, SubjectId, Title, Year, Photo, ISBN, Condition)
	VALUES
	(1, 1, 1, 1, 'Calculus: Graphical, Numerical, Algebraic', 2012, 'pic.png', '978-0495011606', 'Water Damage'),
	(2, 2, 2, 2, 'College Writing Skills with Readings, 11th Edition', 2022, 'pic.png', '1264307012', 'Slightly Worn'),
	(3, 3, 3, 3, 'Essentials of Geology Sixth Edition', 2019, 'pic.png', '0393667537', 'Near Perfect')
END