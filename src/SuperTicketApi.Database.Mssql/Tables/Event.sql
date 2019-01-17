CREATE TABLE [dbo].[Events]
(
	[EventId] int primary key identity,
	[Name] nvarchar(120) NOT NULL,
	[Banner] nvarchar(max) NOT NULL,
	[Description] nvarchar(max) NOT NULL,
	[StartAt] DATETIMEOFFSET NOT NULL,
	[Runtime] TIME(7) NOT NULL,
	[LayoutId] int NOT NULL,
)