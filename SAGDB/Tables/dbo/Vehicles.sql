CREATE TABLE [dbo].[Vehicles]
(
	[VehicleID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CustomID] VARCHAR(50) NULL, 
    [Matricule] NCHAR(10) NULL, 
    [Color] VARCHAR(30) NULL, 
    [Model] VARCHAR(20) NULL, 
    [EngineID] VARCHAR(150) NULL, 
    [NoWheel] INT NULL, 
    [Kilometers] VARCHAR(20) NULL, 
    [Image] VARCHAR(100) NULL, 
    [Status] INT NULL, 
    [Weight] VARCHAR(20) NULL, 
    [Support] VARCHAR(20) NULL, 
    [DateRegister] DATETIME NULL, 
    [UserRegister] VARCHAR(50) NULL
)
