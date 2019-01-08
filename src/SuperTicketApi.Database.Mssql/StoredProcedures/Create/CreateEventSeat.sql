CREATE PROCEDURE [dbo].[CreateEventSeat] @EventAreaId INT
, @Row INT
, @Number INT
, @State INT
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;

		INSERT INTO [dbo].[EventSeats] ([EventAreaId]
		, [Row]
		, [Number]
		, [State])
			VALUES (@EventAreaId, @Row, @Number, @State);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO