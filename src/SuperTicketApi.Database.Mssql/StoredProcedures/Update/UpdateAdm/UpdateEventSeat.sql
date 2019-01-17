CREATE PROCEDURE [adm].[UpdateEventSeat] @EventSeatId INT
, @EventAreaId INT
, @Row INT
, @Number INT
, @State INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		UPDATE [dbo].[EventSeats]
		SET [EventAreaId] = @EventAreaId
		   ,[Row] = @Row
		   ,[Number] = @Number
		   ,[State] = @State
		WHERE IDENTITYCOL = @EventSeatId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO