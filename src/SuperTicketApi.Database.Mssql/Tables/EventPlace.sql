CREATE TABLE [dbo].[EventPlace]
(
	[EventPlaceId] INT NOT NULL PRIMARY KEY, 
	[PlacesAdmin] NVARCHAR(50) NOT NULL, 
	[AdminTelephone] NVARCHAR(50) NOT NULL, 
	[CostPerHour] DECIMAL NOT NULL 
)
