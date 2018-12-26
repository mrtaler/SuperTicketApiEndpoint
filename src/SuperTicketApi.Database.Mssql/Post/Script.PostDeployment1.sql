/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
insert into  [dbo].[EventAddress] 
values(
N'TestStrit1',---[Street] NVARCHAR(50) NULL, 
N'TestHome1',--[House] NVARCHAR(10) NULL, 
N'TestDescription1'),---  [Description] NVARCHAR(500) NULL)	  
( N'TestStrit2', N'TestHome2',N'TestDescription2'),
( N'TestStrit3', N'TestHome3',N'TestDescription3'),
( N'TestStrit4', N'TestHome4',N'TestDescription4'),
( N'TestStrit5', N'TestHome5',N'TestDescription5');

insert into [dbo].[EventPlace]
values (1,--[EventPlaceId] INT NOT NULL PRIMARY KEY, 
N'[PlacesAdmin]1',--	[PlacesAdmin] NVARCHAR(50) NOT NULL, 
N'[AdminTelephone]1',	--[AdminTelephone] NVARCHAR(50) NOT NULL, 
230), --[CostPerHour] DECIMAL NOT NULL )
(2,N'[PlacesAdmin]2',N'[AdminTelephone]2',240),
(3,N'[PlacesAdmin]3',N'[AdminTelephone]3',250),
(4,N'[PlacesAdmin]4',N'[AdminTelephone]4',260),
(5,N'[PlacesAdmin]5',N'[AdminTelephone]5',270);

insert into [dbo].[Events]
values(
N'Name1',--	[Name] nvarchar(120) NOT NULL,
N'Banner1',--	[Banner] nvarchar(max) NOT NULL,
N'Description1',--	[Description] nvarchar(max) NOT NULL,
'2018-12-12 00:00:00.0000000 +03:00', --	[StartAt] DATETIMEOFFSET NOT NULL,
'10:00:00',--	[Runtime] TIME(7) NOT NULL,
1,--	[Fk_EventPlaceId] int NOT NULL, 
20  --  [MaxSeats] INT NOT NULL,
),
( N'Name2',N'Banner2', N'Description2','2018-12-13 00:00:00.0000000 +03:00','10:00:00',2,20),
( N'Name3',N'Banner3', N'Description3','2018-12-14 00:00:00.0000000 +03:00','10:00:00',3,20),
( N'Name4',N'Banner4', N'Description4','2018-12-15 00:00:00.0000000 +03:00','10:00:00',4,20),
( N'Name5',N'Banner5', N'Description5','2018-12-16 00:00:00.0000000 +03:00','10:00:00',5,20),
( N'Name6',N'Banner6', N'Description6','2018-12-17 00:00:00.0000000 +03:00','10:00:00',1,20),
( N'Name7',N'Banner7', N'Description7','2018-12-18 00:00:00.0000000 +03:00','10:00:00',2,20),
( N'Name8',N'Banner8', N'Description8','2018-12-19 00:00:00.0000000 +03:00','10:00:00',3,20),
( N'Name9',N'Banner9', N'Description9','2018-12-20 00:00:00.0000000 +03:00','10:00:00',4,20),
( N'Name10',N'Banner10', N'Description10','2018-12-21 00:00:00.0000000 +03:00','10:00:00',5,20);
