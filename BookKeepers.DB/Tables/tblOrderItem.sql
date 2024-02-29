CREATE TABLE [dbo].[tblOrderItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderId] INT NULL, 
    [BookId] INT NULL, 
    [Quantity] INT NULL, 
    [Cost] FLOAT NULL, 
    [Photo] VARCHAR(50) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Title] VARCHAR(50) NULL
)
