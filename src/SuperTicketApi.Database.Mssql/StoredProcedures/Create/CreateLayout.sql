CREATE PROCEDURE [dbo].[CreateLayout] @VenueId INT
, @Description NVARCHAR(120)
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;

		INSERT INTO [dbo].[Layouts] ([VenueId]
		, [Description])
			VALUES (@VenueId, @Description);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;

	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO