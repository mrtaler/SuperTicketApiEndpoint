ALTER TABLE [dbo].[Events]
	ADD CONSTRAINT [ForeignKey_Event_to_EventPlace]
	FOREIGN KEY ([Fk_EventPlaceId])
	REFERENCES [EventPlace] ([EventPlaceId])
