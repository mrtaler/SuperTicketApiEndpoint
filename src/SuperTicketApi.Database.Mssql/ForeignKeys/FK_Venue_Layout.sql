﻿ALTER TABLE dbo.Layouts
ADD CONSTRAINT FK_Venue_Layout FOREIGN KEY (VenueId)     
    REFERENCES dbo.Venues (VenueId) ON DELETE CASCADE