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
    using SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter;

    /// <summary>
    /// The projections extension methods.
    /// </summary>
    public static class ApiViewModelExtensionMethodsForTest
    {
        /// <summary>
        /// Project a type using a DTO
        /// </summary>
        /// <typeparam name="TProjection">The dto projection</typeparam>
        /// <param name="item">The source entity to project</param>
        /// <returns>The projected type</returns>
        public static TProjection TestProjectedAs<TProjection>(this ApiViewModel item)
            where TProjection : class, new()
        {
            var adapter = new AutomapperTypeAdapterFactory().Create();
            return adapter.Adapt<TProjection>(item);
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

            this.createEventAreaViewModel = new CreateEventAreaViewModel
            {
                CoordX = 1,
                CoordY = 2,
                Description = "CreateEventAreaViewModelDescription",
                EventId = 11,
                Price = 123142M
            };

        }

        /// <summary>
        /// The create area view model return command.
        /// </summary>
        [Test]
        public void CreateAreaViewModelReturnCommand()
        {
            var command = createAreaViewModel.TestProjectedAs<PresenterCreateAreaCommand>();

            Assert.IsInstanceOf<PresenterCreateAreaCommand>(command);
            Assert.AreEqual(command.LayoutId, 1);
            Assert.AreEqual(command.Description, "CreateAreaViewModelDescription");
            Assert.AreEqual(command.CoordX, 2);
            Assert.AreEqual(command.CoordY, 3);
        }

        //[Test]
        //public void createEventAreaViewModelReturnCommand()
        //{
        //    var command = createEventAreaViewModel.TestProjectedAs<PresenterCreateEventAreaCommand>();

        //    Assert.IsInstanceOf<PresenterCreateEventAreaCommand>(command);
        //    Assert.AreEqual(command.EventId, 11);
        //    Assert.AreEqual(command.Description, "CreateEventAreaViewModelDescription");
        //    Assert.AreEqual(command.CoordX, 1);
        //    Assert.AreEqual(command.CoordY, 2);
        //    Assert.AreEqual(command.Price, 123142M);
        //}
    }
}