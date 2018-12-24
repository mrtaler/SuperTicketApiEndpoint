CREATE TABLE [dbo].[EventAddress]
(
	[EventAddressId] INT NOT NULL PRIMARY KEY, 
    [Street] NVARCHAR(50) NULL, 
    [House] NVARCHAR(10) NULL, 
    [Description] NVARCHAR(500) NULL
)
