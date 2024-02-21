BEGIN 
	INSERT INTO tblComment(Id, PostId, UserId, Comment, Condition, CreationDate)
	VALUES
	(1, 1, 1, 'This book is seriously water damaged. Pages warped and stuck together, Many stains and inks runs. You should NOT be selling this garbage! Daughter needed it asap. So it was not an option to return.', '', 2001-03-13),
	(2, 2, 2, 'The book arrived quickly and it was in excellent condition as promised. The book was a gift to my husband and he loves it. I would highly recommend.', '', 2001-03-13),
	(3, 3, 3, 'I bought this book for my freshman year of college and it served its purpose of getting me through my class.', '', 2024-02-13),
	(4, 4, 4, 'Book seems ok aside of front cover has a slice through it.', '', 2001-03-13)
END