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
    using SuperTicketApi.Application.MainContext.Cqrs.Commands.Create;
    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter;
    using SuperTicketApi.Infrastructure.NUnitTest;
    using System;

    [TestFixture]
    public class ConverterCreateCommandShould : TestBase
    {
        private CreateAreaViewModel createAreaViewModel;

        private CreateEventAreaViewModel createEventAreaViewModel;

        private CreateEventViewModel createEventViewModel;

        private CreateEventSeatViewModel createEventSeatViewModel;

        private CreateLayoutViewModel createLayoutViewModel;

        private CreateSeatViewModel createSeatViewModel;

        private CreateVenueViewModel createVenueViewModel;

        public ConverterCreateCommandShould()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile(new UIViewModelToPresenterCommandMapper()); });
            var adapterFactory = TestHelper.MakeMock<ITypeAdapterFactory>(
                x => x.Setup(y => y.Create()).Returns(new AutomapperTypeAdapter()));

            TypeAdapterFactory.SetCurrent(adapterFactory);
        }

        [SetUp]
        public void SetUpConverterCreateCommandShould()
        {
            this.createAreaViewModel = new CreateAreaViewModel
            {
                LayoutId = 1,
                Description = "CreateAreaViewModelDescription",
                CoordX = 2,
                CoordY = 3
            };
            this.createEventAreaViewModel = new CreateEventAreaViewModel
            {
                CoordX = 1,
                CoordY = 2,
                Description = "CreateEventAreaViewModelDescription",
                EventId = 11,
                Price = 123142M
            };
            this.createEventViewModel = new CreateEventViewModel
            {
                Name = "EventName1",
                Banner = "EventBanner1",
                Description = "EventDescription1",
                RunTime = TimeSpan.FromHours(1),
                StartAt = new DateTime(2019, 1, 17, 18, 30, 0),
                LayoutId = 1
            };
            this.createEventSeatViewModel = new CreateEventSeatViewModel
            {
                EventAreasId = 1,
                Row = 2,
                Number = 3,
                State = 4
            };
            this.createLayoutViewModel = new CreateLayoutViewModel { VenueId = 1, Description = "LayoutDescription1" };
            this.createSeatViewModel = new CreateSeatViewModel { AreaId = 1, Row = 1, Number = 1 };
            this.createVenueViewModel = new CreateVenueViewModel
            {
                Description = "VenueDescription1",
                Address = "VenueAddress1",
                Phone = "VenuePhone1"
            };
        }

        /// <summary>
        /// The create area view model return command.
        /// </summary>
        [Test]
        public void ReturnValidPresenterCreateAreaCommand()
        {
            var command = this.createAreaViewModel.ProjectedAs<PresenterCreateAreaCommand>();

            Assert.IsInstanceOf<PresenterCreateAreaCommand>(command);

            Assert.That(command.LayoutId, Is.EqualTo(createAreaViewModel.LayoutId));
            Assert.That(command.Description, Is.EqualTo(createAreaViewModel.Description));
            Assert.That(command.CoordX, Is.EqualTo(createAreaViewModel.CoordX));
            Assert.That(command.CoordY, Is.EqualTo(createAreaViewModel.CoordY));
        }

        [Test]
        public void ReturnValidPresenterCreateEventAreaCommand()
        {
            var command = this.createEventAreaViewModel.ProjectedAs<PresenterCreateEventAreaCommand>();

            Assert.IsInstanceOf<PresenterCreateEventAreaCommand>(command);

            Assert.That(command.EventId, Is.EqualTo(createEventAreaViewModel.EventId));
            Assert.That(command.Description, Is.EqualTo(createEventAreaViewModel.Description));
            Assert.That(command.CoordX, Is.EqualTo(createEventAreaViewModel.CoordX));
            Assert.That(command.CoordY, Is.EqualTo(createEventAreaViewModel.CoordY));
            Assert.That(command.Price, Is.EqualTo(createEventAreaViewModel.Price));
        }

        [Test]
        public void ReturnValidPresenterCreateEventCommand()
        {
            var command = this.createEventViewModel.ProjectedAs<PresenterCreateEventCommand>();
            Assert.IsInstanceOf<PresenterCreateEventCommand>(command);

            Assert.That(command.Name, Is.EqualTo(createEventViewModel.Name));
            Assert.That(command.Banner, Is.EqualTo(createEventViewModel.Banner));
            Assert.That(command.Description, Is.EqualTo(createEventViewModel.Description));
            Assert.That(command.StartAt, Is.EqualTo(createEventViewModel.StartAt));
            Assert.That(command.RunTime, Is.EqualTo(createEventViewModel.RunTime));
            Assert.That(command.LayoutId, Is.EqualTo(createEventViewModel.LayoutId));
        }

        [Test]
        public void ReturnValidPresenterCreateEventSeatCommand()
        {
            var command = this.createEventSeatViewModel.ProjectedAs<PresenterCreateEventSeatCommand>();
            Assert.IsInstanceOf<PresenterCreateEventSeatCommand>(command);

            Assert.That(command.EventAreaId, Is.EqualTo(createEventSeatViewModel.EventAreasId));
            Assert.That(command.Row, Is.EqualTo(createEventSeatViewModel.Row));
            Assert.That(command.Number, Is.EqualTo(createEventSeatViewModel.Number));
            Assert.That(command.State, Is.EqualTo(createEventSeatViewModel.State));
        }

        [Test]
        public void ReturnValidPresenterCreateLayoutCommand()
        {
            var command = this.createLayoutViewModel.ProjectedAs<PresenterCreateLayoutCommand>();
            Assert.IsInstanceOf<PresenterCreateLayoutCommand>(command);

            Assert.That(command.VenueId, Is.EqualTo(createLayoutViewModel.VenueId));
            Assert.That(command.Description, Is.EqualTo(createLayoutViewModel.Description));
        }

        [Test]
        public void ReturnValidPresenterCreateSeatCommand()
        {
            var command = this.createSeatViewModel.ProjectedAs<PresenterCreateSeatCommand>();
            Assert.IsInstanceOf<PresenterCreateSeatCommand>(command);

            Assert.That(command.AreaId, Is.EqualTo(createSeatViewModel.AreaId));
            Assert.That(command.Row, Is.EqualTo(createSeatViewModel.Row));
            Assert.That(command.Number, Is.EqualTo(createSeatViewModel.Number));
        }

        [Test]
        public void ReturnValidPresenterCreateVenueCommand()
        {
            var command = this.createVenueViewModel.ProjectedAs<PresenterCreateVenueCommand>();
            Assert.IsInstanceOf<PresenterCreateVenueCommand>(command);

            Assert.That(command.Description, Is.EqualTo(createVenueViewModel.Description));
            Assert.That(command.Address, Is.EqualTo(createVenueViewModel.Address));
            Assert.That(command.Phone, Is.EqualTo(createVenueViewModel.Phone));
        }

    }
}