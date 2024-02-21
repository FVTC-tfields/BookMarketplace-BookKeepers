CREATE TABLE [dbo].[tblCustomer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NULL, 
    [City] VARCHAR(50) NULL, 
    [State] VARCHAR(50) NULL, 
    [ZIP] VARCHAR(50) NULL, 
    [Phone] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL,
    [FirstName] VARCHAR(50) NULL,
    [LastName] VARCHAR(50) NULL
)
