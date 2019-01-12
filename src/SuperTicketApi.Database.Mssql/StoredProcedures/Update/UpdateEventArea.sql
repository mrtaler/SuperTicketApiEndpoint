CREATE PROCEDURE [dbo].[UpdateEventArea] @EventAreaId INT
, @Description NVARCHAR(200)
, @CoordX INT
, @CoordY INT
, @Price DECIMAL
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[EventAreas]
		SET [Description] = @Description
		   ,[CoordX] = @CoordX
		   ,[CoordY] = @CoordY
		   ,[Price] = @Price
		WHERE IDENTITYCOL = @EventAreaId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO