CREATE TABLE [dbo].[Person]
(
	[PersonID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL, 
    [MiddleName] VARCHAR(30) NOT NULL, 
    [LastName] VARCHAR(30) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Genere] VARCHAR(10) NOT NULL, 
    [Address] VARCHAR(255) NOT NULL, 
    [BloodType] VARCHAR(10) NULL, 
    [Weight] VARCHAR(10) NULL, 
    [Hight] VARCHAR(10) NULL, 
    [Description] TEXT NULL, 
    [Status] BIT NULL, 
    [DateRegister] DATETIME NULL, 
    [UserRegister] VARCHAR(50) NULL
)
