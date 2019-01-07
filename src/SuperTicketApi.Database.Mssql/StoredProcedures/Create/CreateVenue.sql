CREATE PROCEDURE [dbo].[CreateVenue] @Description NVARCHAR(120)
, @Address NVARCHAR(200)
, @Phone NVARCHAR(30)
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;

		INSERT INTO [dbo].[Venues] ([Description]
		, [Address]
		, [Phone])
			VALUES (@Description, @Address, @Phone);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO