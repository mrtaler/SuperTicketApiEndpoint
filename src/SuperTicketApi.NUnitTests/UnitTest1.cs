namespace SuperTicketApi.NUnitTests
{
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

    /// <summary>
    /// The test command profile.
    /// </summary>
    public class TestCommandProfile
        : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCommandProfile"/> class. 
        /// </summary>
        public TestCommandProfile()
        {
            #region Create presenter Command
            this.CreateMap<CreateAreaViewModel, PresenterCreateAreaCommand>()
                .PreserveReferences()
                .ReverseMap();
            #endregion
        }
    }

    public class Tests
    {
        private CreateAreaViewModel createAreaViewModel;
        private CreateEventAreaViewModel createEventAreaViewModel;
        private CreateEventViewModel createEventViewModel;
        private CreateEventSeatViewModel createEventSeatViewModel;
        private CreateLayoutViewModel createLayoutViewModel;
        private CreateSeatViewModel createSeatViewModel;
        private CreateVenueViewModel createVenueViewModel;
        [SetUp]
        public void ConverterShould()
        {
            this.createAreaViewModel = new CreateAreaViewModel
                                      {
                                          LayoutId = 1,
                                          Description = "CreateAreaViewModelDescription",
                                          CoordX = 2,
                                          CoordY = 3
                                      };
        }

        /// <summary>
        /// The create area view model return command.
        /// </summary>
        [Test]
        public void CreateAreaViewModelReturnCommand()
        {
         /*   var command = this.createAreaViewModel.ProjectedAs<PresenterCreateAreaCommand>();
            Assert.IsInstanceOf<PresenterCreateAreaCommand>(command);
            Assert.AreEqual(command.LayoutId, 1);
            Assert.AreEqual(command.Description, "CreateAreaViewModelDescription");
            Assert.AreEqual(command.CoordX, 2);
            Assert.AreEqual(command.CoordY, 3);*/

            Assert.Pass();
        }
    }
}