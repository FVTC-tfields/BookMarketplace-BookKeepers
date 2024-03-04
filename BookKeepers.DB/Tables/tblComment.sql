CREATE TABLE [dbo].[tblComment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PostId] INT NULL, 
    [UserId] INT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Condition] VARCHAR(50) NULL, 
    [CreationDate] VARCHAR(50) NULL
)
