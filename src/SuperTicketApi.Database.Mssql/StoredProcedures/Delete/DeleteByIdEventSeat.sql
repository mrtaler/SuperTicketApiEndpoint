﻿CREATE PROCEDURE [dbo].[DeleteByIdEventSeat] @EventSeatId INT
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRY
		DELETE FROM [dbo].[EventSeats]
		WHERE IDENTITYCOL = @EventSeatId
	END TRY
	BEGIN CATCH
		EXECUTE [dbo].[GetErrorInfo];
	END CATCH
END
GO