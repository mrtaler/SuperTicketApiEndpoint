﻿CREATE PROCEDURE [dbo].[UpdateEvent] @id INT
, @Name NVARCHAR(120)
, @Banner NVARCHAR(MAX)
, @Description NVARCHAR(MAX)
, @StartAt DATETIMEOFFSET
, @Runtime TIME(7)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Events]
		SET [Name] = @Name
		   ,[Banner] = @Banner
		   ,[Description] = @Description
		   ,[StartAt] = @StartAt
		   ,[Runtime] = @Runtime
		WHERE IDENTITYCOL = @id
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO