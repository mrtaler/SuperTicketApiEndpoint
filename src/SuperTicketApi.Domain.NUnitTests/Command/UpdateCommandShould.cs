namespace SuperTicketApi.Domain.NUnitTests.Command
{
    using NUnit.Framework;

    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.Update;

    /// <summary>
    /// The update command should.
    /// </summary>
    public class UpdateCommandShould
    {
        /// <summary>
        /// The return correct adm update area command.
        /// </summary>
        [Test]
        public void ReturnCorrectAdmUpdateAreaCommand()
        {
            var com = new UpdateAreaDomainCommand(true);
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.AdminUpdate.UpdateAreaAdm);
        }

        /// <summary>
        /// The return correct adm update event area command.
        /// </summary>
        [Test]
        public void ReturnCorrectAdmUpdateEventAreaCommand()
        {
            var com = new UpdateEventAreaDomainCommand(true);
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.AdminUpdate.UpdateEventAreaAdm);
        }

        /// <summary>
        /// The return correct adm update event command.
        /// </summary>
        [Test]
        public void ReturnCorrectAdmUpdateEventCommand()
        {
            var com = new UpdateEventDomainCommand(true);
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.AdminUpdate.UpdateEventAdm);
        }

        /// <summary>
        /// The return correct adm update event seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectAdmUpdateEventSeatCommand()
        {
            var com = new UpdateEventSeatDomainCommand(true);
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.AdminUpdate.UpdateEventSeatAdm);
        }

        /// <summary>
        /// The return correct adm update layout command.
        /// </summary>
        [Test]
        public void ReturnCorrectAdmUpdateLayoutCommand()
        {
            var com = new UpdateLayoutDomainCommand(true);
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.AdminUpdate.UpdateLayoutAdm);
        }

        /// <summary>
        /// The return correct adm update seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectAdmUpdateSeatCommand()
        {
            var com = new UpdateSeatDomainCommand(true);
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.AdminUpdate.UpdateSeatAdm);
        }

        /// <summary>
        /// The return correct adm update area command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateAreaCommand()
        {
            var com = new UpdateAreaDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateArea);
        }

        /// <summary>
        /// The return correct adm update event area command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateEventAreaCommand()
        {
            var com = new UpdateEventAreaDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateEventArea);
        }

        /// <summary>
        /// The return correct adm update event command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateEventCommand()
        {
            var com = new UpdateEventDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateEvent);
        }

        /// <summary>
        /// The return correct adm update event seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateEventSeatCommand()
        {
            var com = new UpdateEventSeatDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateEventSeat);
        }

        /// <summary>
        /// The return correct adm update layout command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateLayoutCommand()
        {
            var com = new UpdateLayoutDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateLayout);
        }

        /// <summary>
        /// The return correct adm update seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateSeatCommand()
        {
            var com = new UpdateSeatDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateSeat);
        }

        /// <summary>
        /// The return correct adm update seat command.
        /// </summary>
        [Test]
        public void ReturnCorrectUpdateVenueCommand()
        {
            var com = new UpdateVenueDomainCommand();
            Assert.AreEqual(com.Command, UpdateSpCommandPattern.UpdateVenue);
        }
    }
}