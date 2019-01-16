namespace SuperTicketApi.Domain.NUnitTests.Command
{
    using NUnit.Framework;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;

    /// <summary>
    /// The create new command should.
    /// </summary>
    [TestFixture]
    public class CreateCommandShould
    {
        /// <summary>
        /// The reurn correct create area command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateAreaCommand()
        {
            var com = new CreateAreaDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateArea);
        }

        /// <summary>
        /// The return correct create event area command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateEventAreaCommand()
        {
            var com = new CreateEventAreaDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateEventArea);
        }

        /// <summary>
        /// The return correct create event command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateEventCommand()
        {
            var com = new CreateEventDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateEvent);
        }

        /// <summary>
        /// The return correct create event seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateEventSeatCommand()
        {
            var com = new CreateEventSeatDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateEventSeat);
        }

        /// <summary>
        /// The return correct create layout command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateLayoutCommand()
        {
            var com = new CreateLayoutDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateLayout);
        }

        /// <summary>
        /// The reurn correct create seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateSeatCommand()
        {
            var com = new CreateSeatDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateSeat);
        }

        /// <summary>
        /// The reurn correct create venue command.
        /// </summary>
        [Test]
        public void ReturnCorrectCreateVenueCommand()
        {
            var com = new CreateVenueDomainCommand();
            Assert.AreEqual(com.Command, CreateSpCommandPattern.CreateVenue);
        }
    }
}