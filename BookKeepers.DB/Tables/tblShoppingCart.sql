CREATE TABLE [dbo].[ShoppingCart]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderItemId] INT NULL, 
    [NumberOfItems] INT NULL, 
    [Subtotal] FLOAT NULL, 
    [Tax] FLOAT NULL, 
    [Total] FLOAT NULL
)
