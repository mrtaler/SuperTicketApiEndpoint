CREATE PROCEDURE [dbo].[CreateSeat] @AreaId INT
, @Row INT
, @Number INT
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;

		INSERT INTO [dbo].[Seats] ([AreaId]
		, [Row]
		, [Number])
			VALUES (@AreaId, @Row, @Number);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO