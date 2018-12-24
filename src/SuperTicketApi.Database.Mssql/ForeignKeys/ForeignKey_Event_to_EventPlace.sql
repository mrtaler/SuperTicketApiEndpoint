ALTER TABLE [dbo].[Event]
	ADD CONSTRAINT [ForeignKey_Event_to_EventPlace]
	FOREIGN KEY ([Fk_EventPlaceId])
	REFERENCES [EventPlace] ([EventPlaceId])
