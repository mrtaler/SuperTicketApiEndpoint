CREATE TABLE [dbo].[EventAddress]
(
	[EventAddressId] INT IDENTITY PRIMARY KEY, 
    [Street] NVARCHAR(50) NULL, 
    [House] NVARCHAR(10) NULL, 
    [Description] NVARCHAR(500) NULL
)
