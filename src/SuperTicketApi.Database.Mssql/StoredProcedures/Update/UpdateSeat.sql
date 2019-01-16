CREATE PROCEDURE [dbo].[UpdateSeat] @SeatId INT
, @Row INT
, @Number INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[Seats]
		SET [Row] = @Row
		   ,[Number] = @Number
		WHERE IDENTITYCOL = @SeatId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO