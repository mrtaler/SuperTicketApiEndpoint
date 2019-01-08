﻿CREATE PROCEDURE [dbo].[UpdateVenue] @id INT
, @Description NVARCHAR(120)
, @Address NVARCHAR(200)
, @Phone NVARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Venues]
		SET [Description] = @Description
		   ,[Address] = @Address
		   ,[Phone] = @Phone
		WHERE IDENTITYCOL = @id
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO