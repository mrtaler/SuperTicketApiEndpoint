CREATE PROCEDURE [dbo].[CreateArea] @LayoutId INT
, @Description NVARCHAR(200)
, @CoordX INT
, @CoordY INT
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;
		INSERT INTO [dbo].[Areas] ([LayoutId], [Description], [CoordX], [CoordY])
			VALUES (@LayoutId, @Description, @CoordX, @CoordY);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO