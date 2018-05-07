CREATE TABLE [dbo].[Phone]
(
	[PhoneID] INT NOT NULL PRIMARY KEY, 
    [PersonID] VARCHAR(255) NOT NULL, 
    [PhoneNumber] VARCHAR(20) NULL, 
    [PhoneType] VARCHAR(10) NULL, 
    [Status] BIT NOT NULL, 
    [DateRegister] DATETIME NULL, 
    [UserRegister] VARBINARY(50) NULL
)
