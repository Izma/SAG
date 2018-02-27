CREATE PROCEDURE [dbo].[sp_RegisterPerson]
	@name varchar(100),
	@middleName varchar(30),
	@lastName varchar(30),
	@birthDate date,
	@genere varchar(10),
	@address varchar(255),
	@bloodType varchar(10),
	@weight varchar(10),
	@height varchar(10),
	@description TEXT,
	@status BIT,
	@userRegister VARCHAR(50)
AS
	BEGIN
	BEGIN TRY
INSERT INTO [dbo].[Person]
           ([PersonID]
           ,[Name]
           ,[MiddleName]
           ,[LastName]
           ,[BirthDate]
           ,[Genere]
           ,[Address]
           ,[BloodType]
           ,[Weight]
           ,[Hight]
           ,[Description]
           ,[Status]
           ,[DateRegister]
           ,[UserRegister])
     VALUES
           (NEWID()
           ,@name
           ,@middleName
           ,@lastName
           ,@birthDate
           ,@genere
           ,@address
           ,@bloodType
           ,@weight
           ,@height
           ,@description
           ,@status
           ,GETDATE()
           ,@userRegister);
		    SELECT 'success' AS msg, 1 AS number;
		   END TRY
		   BEGIN CATCH
              SELECT ERROR_MESSAGE() as msg,
                    ERROR_NUMBER() number;
		   END CATCH
		   END


