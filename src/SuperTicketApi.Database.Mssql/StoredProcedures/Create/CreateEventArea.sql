CREATE PROCEDURE [dbo].[CreateEventArea] @EventId INT
, @Description NVARCHAR(200)
, @CoordX INT
, @CoordY INT
, @Price DECIMAL
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;

		INSERT INTO [dbo].[EventAreas] ([EventId]
		, [Description]
		, [CoordX]
		, [CoordY]
		, [Price])
			VALUES (@EventId, @Description, @CoordX, @CoordY, @Price);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO