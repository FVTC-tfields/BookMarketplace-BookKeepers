CREATE TABLE [dbo].[tblComment]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PostId] INT NULL, 
    [UserId] INT NULL, 
    [Description] VARCHAR(50) NULL, 
    [Status] VARCHAR(50) NULL, 
    [CreationDate] DATE NULL
)
