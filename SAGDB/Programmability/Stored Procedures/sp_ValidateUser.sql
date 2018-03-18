CREATE PROCEDURE dbo.sp_ValidateUser @email VARCHAR (255),
 @password VARCHAR (255) AS
BEGIN
	DECLARE
		@pass VARCHAR (255) = (
			SELECT
				CONVERT (
					VARCHAR (255),
					DECRYPTBYPASSPHRASE (
						'SAGP@$$w0rd!!#',
						u.Password
					)
				)
			FROM
				Users AS u
			WHERE
				u.Email = @email
		) ;
	IF @password = @pass SELECT
		1 AS code,
		CONVERT (VARCHAR(255), u.UserId) AS userId
	FROM
		Users AS u
	WHERE
		u.Email = @email
	IF @password <> @pass SELECT
		2 AS code,
		0 AS userId
	IF (
		NOT (
			EXISTS (
				SELECT
					u.Email
				FROM
					Users u
				WHERE
					u.Email =@email
			)
		)
	) SELECT
		3 AS code,
		0 AS userId ;
	END