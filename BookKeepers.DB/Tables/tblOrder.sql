CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NULL, 
    [UserId] INT NULL, 
    [OrderDate] DATETIME NULL, 
    [ShipDate] DATETIME NULL, 
    [SubTotal] FLOAT NULL, 
    [Total] FLOAT NULL, 
    [Tax] FLOAT NULL
)
