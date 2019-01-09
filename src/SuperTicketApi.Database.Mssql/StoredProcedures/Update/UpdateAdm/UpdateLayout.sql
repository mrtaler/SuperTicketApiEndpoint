CREATE PROCEDURE [adm].[UpdateLayout] @id INT
, @VenueId INT
, @Description NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Layouts]
		SET [Description] = @Description
		   ,[VenueId] = @VenueId
		WHERE IDENTITYCOL = @id
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO