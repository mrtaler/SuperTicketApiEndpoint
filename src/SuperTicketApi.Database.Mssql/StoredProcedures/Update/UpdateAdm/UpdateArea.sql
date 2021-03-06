﻿CREATE PROCEDURE [adm].[UpdateArea] @AreaId INT
, @LayoutId INT
, @Description NVARCHAR(200)
, @CoordX INT
, @CoordY INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Areas]
		SET [LayoutId] = @LayoutId
		   ,[Description] = @Description
		   ,[CoordX] = @CoordX
		   ,[CoordY] = @CoordY
		WHERE IDENTITYCOL = @AreaId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO