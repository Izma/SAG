CREATE TABLE [dbo].[Rol]
(
	[RolId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] VARCHAR(50) NOT NULL, 
    [Status] BIT NOT NULL
)
