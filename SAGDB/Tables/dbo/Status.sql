CREATE TABLE [dbo].[Status]
(
	[StatusID] INT NOT NULL PRIMARY KEY, 
    [Status] VARCHAR(50) NOT NULL, 
	[IsActive] BIT NOT NULL, 
    [DateRegister] DATETIME NULL,     
    [UserRegister] DATETIME NULL
)
