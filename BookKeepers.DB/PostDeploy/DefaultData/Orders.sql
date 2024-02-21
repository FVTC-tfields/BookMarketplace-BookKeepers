BEGIN
	INSERT INTO tblOrder (Id, CustomerId, OrderDate, ShipDate, UserId)
	VALUES
	(1, 1, '2024-1-1', '2024-1-2', 1),
	(2, 2, '2024-2-1', '2024-2-2', 2),
	(3, 3, '2024-3-1', '2024-3-2', 3)
END