CREATE TABLE [dbo].[Menu]
(
	[MenuID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(100) NOT NULL, 
    [Route] VARCHAR(150) NOT NULL, 
    [ParentID] INT NOT NULL, 
    [IsActive] BIT NOT NULL, 
    [DateRegister] DATETIME NULL, 
    [UserRegister] VARCHAR(50) NULL
)
