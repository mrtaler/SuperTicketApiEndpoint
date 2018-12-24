ALTER TABLE [dbo].[EventPlace]
	ADD CONSTRAINT [ForeignKey_EventPlace_to_EventAddress]
	FOREIGN KEY ([EventPlaceId])
	REFERENCES [EventAddress] ([EventAddressId])
