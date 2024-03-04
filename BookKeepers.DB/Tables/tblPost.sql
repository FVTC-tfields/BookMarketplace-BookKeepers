CREATE TABLE [dbo].[tblPost]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [BookId] INT NULL, 
    [ConditionId] INT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [Price] FLOAT NULL 
)
