﻿CREATE PROCEDURE [dbo].[DeleteByIdEventArea] @EventAreaId INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM [dbo].[EventAreas]
		WHERE IDENTITYCOL = @EventAreaId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO