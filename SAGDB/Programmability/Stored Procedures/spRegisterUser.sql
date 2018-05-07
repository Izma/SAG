-- =============================================
-- Author:		Ismael López Aguilar
-- Create date: 29-11-2017
-- Description:	New user
-- =============================================
CREATE PROCEDURE [dbo].[spRegisterUser] @Email        VARCHAR(255),
                           @Password     VARCHAR(255),
                           @Name         VARCHAR(50),
                           @MiddleName   VARCHAR(40),
                           @LastName     VARCHAR(40),
                           @NickName     VARCHAR(20),
                           @UserRegister VARCHAR(255)
AS
     BEGIN
         BEGIN TRY
             INSERT INTO [dbo].[User]
             ([UserId],
              [Email],
              [Password],
              [Name],
              [MiddleName],
              [LastName],
              [NickName],
              [DateRegister],
              [UserRegister]
             )
             VALUES
             (NEWID(),
              @Email,
             ENCRYPTBYPASSPHRASE('SAGP@$$w0rd!!#',@Password),
              @Name,
              @MiddleName,
              @LastName,
              @NickName,
              GETDATE(),
              @UserRegister
             );
            SELECT 'success' as msg, 1 as number;
         END TRY
         BEGIN CATCH
	     SELECT ERROR_MESSAGE() Message,
                    ERROR_NUMBER() Number;
         END CATCH;
     END;
