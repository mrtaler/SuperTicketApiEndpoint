CREATE TABLE [dbo].[Seats]
(
	[SeatId] int identity primary key,
	[AreaId] int NOT NULL,
	[Row] int NOT NULL,
	[Number] int NOT NULL,
)