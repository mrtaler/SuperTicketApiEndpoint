﻿/*
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
-- venue

insert into dbo.Venues
values ('cinema of Kalinina', 'Kommunarow Street 4, Gomel', '8 0232 75-57-51'),
('cinema Oktyabr', 'Barykina Street 127, Gomel', '8 0232 40-80-40'),
('cinema Mir', 'Ilyicha Street 516, Gomel', '8 0232 36-13-60')

-- layout
insert into dbo.Layouts
values (1, 'Grand Hall'),
(1, 'Little Hall'),
(2, 'Premier Hall'),
(2, 'Vip Hall'),
(3, 'Hall of Mir')

-- area
insert into dbo.Areas
values (1, 'Parter', 1, 1),
(1, 'Lodge', 1, 2),
(2, 'Parter', 1, 1),
(2, 'VIP', 2, 1),
(3, 'Parter', 1, 1),
(3, 'Balkon', 1, 2),
(4, 'Parter', 1, 1),
(5, 'Parter', 1, 1),
(5, 'Lodge', 2, 1)

-- seat
insert into dbo.Seats
values (1, 1, 1),
(1, 1, 2),
(1, 1, 3),
(1, 2, 1),
(1, 2, 2),
(1, 2, 3),
(2, 1, 1),
(2, 1, 2),
(2, 1, 3),
(2, 1, 4),
(2, 1, 5),
(3, 1, 1),
(3, 1, 2),
(3, 1, 3),
(3, 2, 1),
(3, 2, 2),
(3, 2, 3),
(4, 1, 1),
(4, 1, 2),
(4, 1, 3),
(4, 1, 4),
(4, 1, 5),
(5, 1, 1),
(5, 1, 2),
(5, 1, 3),
(5, 2, 1),
(5, 2, 2),
(5, 2, 3),
(6, 1, 1),
(6, 1, 2),
(6, 1, 3),
(6, 2, 1),
(6, 2, 2),
(7, 1, 1),
(7, 1, 2),
(7, 1, 3),
(7, 2, 1),
(7, 2, 2),
(7, 2, 3),
(8, 1, 1),
(8, 1, 2),
(8, 1, 3),
(8, 2, 1),
(8, 2, 2),
(8, 2, 3),
(9, 1, 1),
(9, 1, 2),
(9, 1, 3),
(9, 1, 4),
(9, 1, 5)

-- event
insert into dbo.Events
values ('Kingsman: The Golden Circle', 'image', 'When their headquarters are destroyed and the world is held hostage, the Kingsmans journey leads them to the discovery of an allied spy organization in the US.', DATETIMEFROMPARTS(2017, 09, 20, 18, 30, 0, 0), TIMEFROMPARTS(02, 10, 0, 0, 0), 1),
('Thor: Ragnarok', 'image', 'Imprisoned, the mighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally.', DATETIMEFROMPARTS(2017, 09, 25, 18, 00, 0, 0), TIMEFROMPARTS(01, 43, 0, 0, 0), 2),
('Kingsman: The Golden Circle', 'image', 'When their headquarters are destroyed and the world is held hostage, the Kingsmans journey leads them to the discovery of an allied spy organization in the US.', DATETIMEFROMPARTS(2017, 10, 01, 15, 30, 0, 0), TIMEFROMPARTS(02, 10, 0, 0, 0), 3),
('Thor: Ragnarok', 'image', 'Imprisoned, the mighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally.', DATETIMEFROMPARTS(2017, 10, 12, 20, 30, 0, 0), TIMEFROMPARTS(01, 43, 0, 0, 0), 4),
('Kingsman: The Golden Circle', 'image', 'When their headquarters are destroyed and the world is held hostage, the Kingsmans journey leads them to the discovery of an allied spy organization in the US.', DATETIMEFROMPARTS(2017, 09, 18, 18, 00, 0, 0), TIMEFROMPARTS(02, 10, 0, 0, 0), 5),
('Thor: Ragnarok', 'image', 'Imprisoned, the mighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally.', DATETIMEFROMPARTS(2017, 09, 30, 16, 30, 0, 0), TIMEFROMPARTS(01, 43, 0, 0, 0), 5),
('Kingsman: The Golden Circle', 'image', 'When their headquarters are destroyed and the world is held hostage, the Kingsmans journey leads them to the discovery of an allied spy organization in the US.', DATETIMEFROMPARTS(2017, 10, 15, 19, 30, 0, 0), TIMEFROMPARTS(02, 10, 0, 0, 0), 2),
('Thor: Ragnarok', 'image', 'Imprisoned, the mighty Thor finds himself in a lethal gladiatorial contest against the Hulk, his former ally.', DATETIMEFROMPARTS(2017, 09, 29, 19, 30, 0, 0), TIMEFROMPARTS(01, 43, 0, 0, 0), 1)

-- eventArea
insert into dbo.EventAreas
values (1, 'Parter', 1, 1, 4.55),
(1, 'Lodge', 1, 2, 7.35),
(2, 'Parter', 1, 1, 5.05),
(2, 'VIP', 2, 1, 10.00),
(3, 'Parter', 1, 1, 4.35),
(3, 'Balkon', 1, 2, 3.55),
(4, 'Parter', 1, 1, 4.10),
(5, 'Parter', 1, 1, 6.70),
(5, 'Lodge', 2, 1, 9.80),
(6, 'Parter', 1, 1, 5.70),
(6, 'Lodge', 2, 1, 6.15),
(7, 'Parter', 1, 1, 4.20),
(7, 'VIP', 2, 1, 11.95),
(8, 'Parter', 1, 1, 4.45),
(8, 'Lodge', 1, 2, 6.20)

-- eventSeat
insert into dbo.EventSeats
values (1, 1, 1, 0),
(1, 1, 2, 1),
(1, 1, 3, 0),
(1, 2, 1, 0),
(1, 2, 2, 0),
(1, 2, 3, 1),
(2, 1, 1, 0),
(2, 1, 2, 1),
(2, 1, 3, 0),
(2, 1, 4, 1),
(2, 1, 5, 1),
(3, 1, 1, 1),
(3, 1, 2, 1),
(3, 1, 3, 0),
(3, 2, 1, 0),
(3, 2, 2, 1),
(3, 2, 3, 1),
(4, 1, 1, 1),
(4, 1, 2, 0),
(4, 1, 3, 0),
(4, 1, 4, 1),
(4, 1, 5, 1),
(5, 1, 1, 1),
(5, 1, 2, 1),
(5, 1, 3, 1),
(5, 2, 1, 1),
(5, 2, 2, 0),
(5, 2, 3, 0),
(6, 1, 1, 1),
(6, 1, 2, 1),
(6, 1, 3, 0),
(6, 1, 4, 1),
(6, 1, 5, 0),
(7, 1, 1, 0),
(7, 1, 2, 0),
(7, 1, 3, 0),
(7, 2, 1, 0),
(7, 2, 2, 0),
(7, 2, 3, 0),
(8, 1, 1, 1),
(8, 1, 2, 1),
(8, 1, 3, 0),
(8, 2, 1, 1),
(8, 2, 2, 1),
(8, 2, 3, 0),
(9, 1, 1, 1),
(9, 1, 2, 1),
(9, 1, 3, 1),
(9, 1, 4, 1),
(9, 1, 5, 1),
(10, 1, 1, 0),
(10, 1, 2, 0),
(10, 1, 3, 1),
(10, 2, 1, 1),
(10, 2, 2, 1),
(10, 2, 3, 0),
(11, 1, 1, 0),
(11, 1, 2, 1),
(11, 1, 3, 0),
(11, 1, 4, 0),
(11, 1, 5, 0),
(12, 1, 1, 1),
(12, 1, 2, 0),
(12, 1, 3, 1),
(12, 2, 1, 1),
(12, 2, 2, 0),
(12, 2, 3, 1),
(13, 1, 1, 1),
(13, 1, 2, 0),
(13, 1, 3, 0),
(13, 1, 4, 0),
(13, 1, 5, 1),
(14, 1, 1, 1),
(14, 1, 2, 1),
(14, 1, 3, 1),
(14, 2, 1, 1),
(14, 2, 2, 1),
(14, 2, 3, 1),
(15, 1, 1, 0),
(15, 1, 2, 0),
(15, 1, 3, 0),
(15, 1, 4, 1),
(15, 1, 5, 1)