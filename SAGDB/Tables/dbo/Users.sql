CREATE TABLE [dbo].[Users]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Email] VARCHAR(255) NOT NULL, 
    [Password] VARBINARY(8000) NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [MiddleName] VARCHAR(40) NOT NULL, 
    [LastName] VARCHAR(40) NULL, 
    [NickName] VARCHAR(20) NULL, 
    [Image] IMAGE NULL, 
    [LastSession] DATETIME NULL, 
    [DateRegister] DATE NULL, 
    [UserRegister] VARCHAR(255) NULL
)
