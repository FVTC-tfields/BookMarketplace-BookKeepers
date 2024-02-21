CREATE TABLE [dbo].[tblBook]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AuthorId] INT NULL, 
    [PublisherId] INT NULL, 
    [SubjectId] INT NULL, 
    [Title] VARCHAR(50) NULL, 
    [Year] DATE NULL, 
    [Photo] VARCHAR(50) NULL, 
    [ISBN] VARCHAR(25) NULL, 
    [Condition] VARCHAR(50) NULL
)
