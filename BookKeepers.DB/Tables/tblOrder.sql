CREATE TABLE [dbo].[tblOrder]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NULL, 
    [UserId] INT NULL, 
    [OrderDate] VARCHAR(50) NULL, 
    [ShipDate] VARCHAR(50) NULL, 
    [SubTotal] FLOAT NULL, 
    [Total] FLOAT NULL, 
    [Tax] FLOAT NULL
)
