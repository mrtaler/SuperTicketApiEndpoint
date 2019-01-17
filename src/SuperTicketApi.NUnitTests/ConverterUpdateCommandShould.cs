namespace SuperTicketApi.NUnitTests
{
    using AutoMapper;
    using NUnit.Framework;
    using SuperTicketApi.ApiEndpoint.ViewModel;
    using SuperTicketApi.ApiEndpoint.ViewModel.Area;
    using SuperTicketApi.ApiEndpoint.ViewModel.Event;
    using SuperTicketApi.ApiEndpoint.ViewModel.EventArea;
    using SuperTicketApi.ApiEndpoint.ViewModel.EventSeat;
    using SuperTicketApi.ApiEndpoint.ViewModel.Layout;
    using SuperTicketApi.ApiEndpoint.ViewModel.Seat;
    using SuperTicketApi.ApiEndpoint.ViewModel.Venue;
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Update;
    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter;
    using SuperTicketApi.Infrastructure.NUnitTest;
    using System;

    [TestFixture]
    public class ConverterUpdateCommandShould : TestBase
    {
        private UpdateAreaViewModel UpdateAreaViewModel;

        private UpdateEventAreaViewModel UpdateEventAreaViewModel;

        private UpdateEventViewModel UpdateEventViewModel;

        private UpdateEventSeatViewModel UpdateEventSeatViewModel;

        private UpdateLayoutViewModel UpdateLayoutViewModel;

        private UpdateSeatViewModel UpdateSeatViewModel;

        private UpdateVenueViewModel UpdateVenueViewModel;

        public ConverterUpdateCommandShould()
        {
            var adapterFactory = this.TestHelper.MakeMock<ITypeAdapterFactory>(
                x => x.Setup(y => y.Create()).Returns(new AutomapperTypeAdapter()));

            TypeAdapterFactory.SetCurrent(adapterFactory);
        }

        [SetUp]
        public void SetUpConverterUpdateCommandShould()
        {
            this.UpdateAreaViewModel = new UpdateAreaViewModel
            {
                Id = 1,
                LayoutId = 1,
                Description = "UpdateAreaViewModelDescription",
                CoordX = 2,
                CoordY = 3
            };
            this.UpdateEventAreaViewModel = new UpdateEventAreaViewModel
            {
                Id = 2,
                CoordX = 1,
                CoordY = 2,
                Description = "UpdateEventAreaViewModelDescription",
                EventId = 11,
                Price = 123142M
            };
            this.UpdateEventViewModel = new UpdateEventViewModel
            {
                Id = 3,
                Name = "EventName1",
                Banner = "EventBanner1",
                Description = "EventDescription1",
                RunTime = TimeSpan.FromHours(1),
                StartAt = new DateTime(2019, 1, 17, 18, 30, 0),
                LayoutId = 1
            };
            this.UpdateEventSeatViewModel = new UpdateEventSeatViewModel
            {
                Id = 4,
                EventAreaId = 1,
                Row = 2,
                Number = 3,
                State = 4
            };
            this.UpdateLayoutViewModel = new UpdateLayoutViewModel { Id = 5, VenueId = 1, Description = "LayoutDescription1" };
            this.UpdateSeatViewModel = new UpdateSeatViewModel { Id = 6, AreaId = 1, Row = 1, Number = 1 };
            this.UpdateVenueViewModel = new UpdateVenueViewModel
            {
                Id = 7,
                Description = "VenueDescription1",
                Address = "VenueAddress1",
                Phone = "VenuePhone1"
            };
        }

        /// <summary>
        /// The Update area view model return command.
        /// </summary>
        [Test]
        public void ReturnValidPresenterUpdateAreaCommand()
        {
            var command = this.UpdateAreaViewModel.ProjectedAs<PresenterUpdateAreaCommand>();

            Assert.IsInstanceOf<PresenterUpdateAreaCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateAreaViewModel.Id));
            Assert.That(command.LayoutId, Is.EqualTo(this.UpdateAreaViewModel.LayoutId));
            Assert.That(command.Description, Is.EqualTo(this.UpdateAreaViewModel.Description));
            Assert.That(command.CoordX, Is.EqualTo(this.UpdateAreaViewModel.CoordX));
            Assert.That(command.CoordY, Is.EqualTo(this.UpdateAreaViewModel.CoordY));
        }

        [Test]
        public void ReturnValidPresenterUpdateEventAreaCommand()
        {
            var command = this.UpdateEventAreaViewModel.ProjectedAs<PresenterUpdateEventAreaCommand>();

            Assert.IsInstanceOf<PresenterUpdateEventAreaCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateEventAreaViewModel.Id));
            Assert.That(command.EventId, Is.EqualTo(this.UpdateEventAreaViewModel.EventId));
            Assert.That(command.Description, Is.EqualTo(this.UpdateEventAreaViewModel.Description));
            Assert.That(command.CoordX, Is.EqualTo(this.UpdateEventAreaViewModel.CoordX));
            Assert.That(command.CoordY, Is.EqualTo(this.UpdateEventAreaViewModel.CoordY));
            Assert.That(command.Price, Is.EqualTo(this.UpdateEventAreaViewModel.Price));
        }

        [Test]
        public void ReturnValidPresenterUpdateEventCommand()
        {
            var command = this.UpdateEventViewModel.ProjectedAs<PresenterUpdateEventCommand>();
            Assert.IsInstanceOf<PresenterUpdateEventCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateEventViewModel.Id));
            Assert.That(command.Name, Is.EqualTo(this.UpdateEventViewModel.Name));
            Assert.That(command.Banner, Is.EqualTo(this.UpdateEventViewModel.Banner));
            Assert.That(command.Description, Is.EqualTo(this.UpdateEventViewModel.Description));
            Assert.That(command.StartAt, Is.EqualTo(this.UpdateEventViewModel.StartAt));
            Assert.That(command.RunTime, Is.EqualTo(this.UpdateEventViewModel.RunTime));
            Assert.That(command.LayoutId, Is.EqualTo(this.UpdateEventViewModel.LayoutId));
        }

        [Test]
        public void ReturnValidPresenterUpdateEventSeatCommand()
        {
            var command = this.UpdateEventSeatViewModel.ProjectedAs<PresenterUpdateEventSeatCommand>();
            Assert.IsInstanceOf<PresenterUpdateEventSeatCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateEventSeatViewModel.Id));
            Assert.That(command.EventAreaId, Is.EqualTo(this.UpdateEventSeatViewModel.EventAreaId));
            Assert.That(command.Row, Is.EqualTo(this.UpdateEventSeatViewModel.Row));
            Assert.That(command.Number, Is.EqualTo(this.UpdateEventSeatViewModel.Number));
            Assert.That(command.State, Is.EqualTo(this.UpdateEventSeatViewModel.State));
        }

        [Test]
        public void ReturnValidPresenterUpdateLayoutCommand()
        {
            var command = this.UpdateLayoutViewModel.ProjectedAs<PresenterUpdateLayoutCommand>();
            Assert.IsInstanceOf<PresenterUpdateLayoutCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateLayoutViewModel.Id));
            Assert.That(command.VenueId, Is.EqualTo(this.UpdateLayoutViewModel.VenueId));
            Assert.That(command.Description, Is.EqualTo(this.UpdateLayoutViewModel.Description));
        }

        [Test]
        public void ReturnValidPresenterUpdateSeatCommand()
        {
            var command = this.UpdateSeatViewModel.ProjectedAs<PresenterUpdateSeatCommand>();
            Assert.IsInstanceOf<PresenterUpdateSeatCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateSeatViewModel.Id));
            Assert.That(command.AreaId, Is.EqualTo(this.UpdateSeatViewModel.AreaId));
            Assert.That(command.Row, Is.EqualTo(this.UpdateSeatViewModel.Row));
            Assert.That(command.Number, Is.EqualTo(this.UpdateSeatViewModel.Number));
        }

        [Test]
        public void ReturnValidPresenterUpdateVenueCommand()
        {
            var command = this.UpdateVenueViewModel.ProjectedAs<PresenterUpdateVenueCommand>();
            Assert.IsInstanceOf<PresenterUpdateVenueCommand>(command);

            Assert.That(command.Id, Is.EqualTo(this.UpdateVenueViewModel.Id));
            Assert.That(command.Description, Is.EqualTo(this.UpdateVenueViewModel.Description));
            Assert.That(command.Address, Is.EqualTo(this.UpdateVenueViewModel.Address));
            Assert.That(command.Phone, Is.EqualTo(this.UpdateVenueViewModel.Phone));
        }

    }
}