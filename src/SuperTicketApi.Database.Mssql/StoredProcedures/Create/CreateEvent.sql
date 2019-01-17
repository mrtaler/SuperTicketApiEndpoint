CREATE PROCEDURE [dbo].[CreateEvent] @Name NVARCHAR(120)
, @Banner NVARCHAR(MAX)
, @Description NVARCHAR(MAX)
, @StartAt DATETIMEOFFSET
, @Runtime TIME(7)
, @LayoutId INT
, @AddedId INT OUTPUT
AS
BEGIN
	BEGIN TRY
		DECLARE @newID INT;

		INSERT INTO [dbo].[Events] ([Name],
		[Banner],
		[Description],
		[StartAt],
		[Runtime],
		[LayoutId])
			VALUES (@Name, @Banner, @Description, @StartAt, @Runtime, @LayoutId);

		SELECT
			@newID = SCOPE_IDENTITY();
		SET @AddedId = @newID;
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO