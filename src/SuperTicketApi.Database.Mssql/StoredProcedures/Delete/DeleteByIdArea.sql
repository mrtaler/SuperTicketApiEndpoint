﻿CREATE PROCEDURE [dbo].[DeleteByIdArea] @AreaId INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY

		DELETE FROM [dbo].[Areas]
		WHERE IDENTITYCOL = @AreaId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO