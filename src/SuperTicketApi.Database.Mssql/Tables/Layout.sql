CREATE TABLE [dbo].[Layouts]
(
	[LayoutId] int identity primary key,
	[VenueId] int NOT NULL,
	[Description] nvarchar(120) NOT NULL,
)
