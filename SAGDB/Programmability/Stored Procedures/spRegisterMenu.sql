CREATE PROCEDURE [dbo].[spRegisterMenu] 
	@Description VARCHAR(100),
	@Route VARCHAR(150),
	@ParentID INT,
	@IsActive BIT,
	@UserRegister VARCHAR(50)
	AS
BEGIN
BEGIN TRY
	INSERT INTO [dbo].[Menu] (
		[Description],
		[Route],
		[ParentID],
		[IsActive],
		[DateRegister],
		[UserRegister]
	)
VALUES
	(
		@Description,
		@Route,
		@ParentID,
		@IsActive,
		GETDATE(),
		@UserRegister
	);
  SELECT 'success' AS msg, 1 AS number;
		   END TRY
		   BEGIN CATCH
              SELECT ERROR_MESSAGE() as msg,
                    ERROR_NUMBER() number;
		   END CATCH
END