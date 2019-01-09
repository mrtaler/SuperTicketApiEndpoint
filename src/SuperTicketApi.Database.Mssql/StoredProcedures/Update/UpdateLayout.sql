CREATE PROCEDURE [dbo].[UpdateLayout] @LayoutId INT
, @Description NVARCHAR(120)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Layouts]
		SET [Description] = @Description
		WHERE IDENTITYCOL = @LayoutId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO