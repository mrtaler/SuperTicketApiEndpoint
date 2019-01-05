CREATE TABLE [dbo].[EventSeats]
(
	[EventSeatId] int identity primary key,
	[EventAreaId] int NOT NULL,
	[Row] int NOT NULL,
	[Number] int NOT NULL,
	[State] int NOT NULL
)
