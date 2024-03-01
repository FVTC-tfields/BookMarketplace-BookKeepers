CREATE TABLE [dbo].[tblComment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PostId] INT NULL, 
    [UserId] INT NULL, 
    [Comment] VARCHAR(MAX) NULL, 
    [Condition] VARCHAR(50) NULL, 
    [CreationDate] VARCHAR(50) NULL
)
