CREATE PROCEDURE [dbo].[UpdateLayout] @id INT
, @Description NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Layouts]
		SET [Description] = @Description
		WHERE IDENTITYCOL = @id
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO