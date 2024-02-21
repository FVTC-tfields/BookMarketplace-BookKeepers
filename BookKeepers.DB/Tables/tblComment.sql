CREATE TABLE [dbo].[tblComment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PostId] INT NULL, 
    [UserId] INT NULL, 
    [Comment] VARCHAR(50) NULL, 
    [Condition] VARCHAR(50) NULL, 
    [CreationDate] DATE NULL
)
