CREATE PROCEDURE dbo.sp_GetInfoUser
                 @userId VARCHAR(255)
AS
     BEGIN
         SELECT CONVERT(varchar(255),u.UserId) userId, u.LastSession, u.Email , u.Image , u.NickName , CONCAT(u.Name , ' ' , u.MiddleName , ' ' , u.LastName) AS FullName
         FROM Users AS u
         WHERE u.UserId = @userId;
     END;
