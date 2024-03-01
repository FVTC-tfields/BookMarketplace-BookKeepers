BEGIN 
	INSERT INTO tblOrderItem (Id,OrderId,BookId,Quantity,Cost,Photo,Description,Title)
	VALUES
	(1,1,1,1,10,'pic.png','This is a book about a guy','Ready Player one'),
	(2,2,2,1,15,'pic.png','This is a book about A kid','Harry Potter'),
	(3,3,3,1,20,'pic.png','This is a book about a Kid','Percy Jackson'),
	(4,4,4,1,7,'pic.png','This is a book about a Girl','Hunger Games')
END