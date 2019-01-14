namespace SuperTicketApi.Domain.NUnitTests.Command
{
    using NUnit.Framework;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.Delete;

    /// <summary>
    /// The create new command should.
    /// </summary>
    [TestFixture]
    public class DeleteCommandShould
    {
        /// <summary>
        /// The reurn correct create area command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteAreaCommand()
        {
            var com = new DeleteAreaDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteArea);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }

        /// <summary>
        /// The return correct Delete event area command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteEventAreaCommand()
        {
            var com = new DeleteEventAreaDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteEventArea);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }

        /// <summary>
        /// The return correct Delete event command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteEventCommand()
        {
            var com = new DeleteEventDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteEvent);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }

        /// <summary>
        /// The return correct Delete event seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteEventSeatCommand()
        {
            var com = new DeleteEventSeatDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteEventSeat);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }

        /// <summary>
        /// The return correct Delete layout command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteLayoutCommand()
        {
            var com = new DeleteLayoutDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteLayout);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }

        /// <summary>
        /// The reurn correct Delete seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteSeatCommand()
        {
            var com = new DeleteSeatDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteSeat);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }

        /// <summary>
        /// The reurn correct Delete venue command.
        /// </summary>
        [Test]
        public void ReturnCorrectDeleteVenueCommand()
        {
            var com = new DeleteVenueDomainCommand(1);
            Assert.AreEqual(com.Command, DeleteSpCommandPattern.DeleteVenue);
            Assert.NotNull(com.Id);
            Assert.AreEqual(com.Id, 1);
        }
    }
}