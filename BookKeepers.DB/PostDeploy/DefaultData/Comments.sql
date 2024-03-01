BEGIN 
	INSERT INTO tblComment(Id, PostId, UserId, Comment, Condition, CreationDate)
	VALUES
	(1, 1, 1, 'This book is seriously water damaged.', '', ''),
	(2, 2, 2, 'The book arrived I would highly recommend.', '', ''),
	(3, 3, 3, 'I bought this book my class.', '', ''),
	(4, 4, 4, 'Book seems ok aside  it.', '', '')
END