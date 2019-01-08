CREATE PROCEDURE [adm].[UpdateEventArea] @id INT
, @EventId INT
, @Description NVARCHAR(200)
, @CoordX INT
, @CoordY INT
, @Price DECIMAL
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[EventAreas]
		SET [EventId] = @EventId
		   ,[Description] = @Description
		   ,[CoordX] = @CoordX
		   ,[CoordY] = @CoordY
		   ,[Price] = @Price
		WHERE IDENTITYCOL = @id
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO