﻿CREATE PROCEDURE [dbo].[UpdateArea] @AreaId INT
, @Description NVARCHAR(200)
, @CoordX INT
, @CoordY INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Areas]
		SET [Description] = @Description
		   ,[CoordX] = @CoordX
		   ,[CoordY] = @CoordY
		WHERE IDENTITYCOL = @AreaId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO