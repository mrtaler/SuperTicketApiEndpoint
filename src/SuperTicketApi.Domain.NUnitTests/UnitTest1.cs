namespace SuperTicketApi.Domain.NUnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MediatR;

    using Moq;

    using NUnit.Framework;

    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Repositories;
    using SuperTicketApi.Domain.Seedwork.Repository;

    /// <summary>
    /// The get area as i enumerable query handler should.
    /// </summary>
    [TestFixture]
    public class GetAreaAsIEnumerableQueryHandlerShould
    {
        /// <summary>
        /// The area repository.
        /// </summary>
        private Mock<IAreaRepository> areaRepository;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private Mock<ITabledUnitOfWork> unitOfWork;

        /// <summary>
        /// The objects.
        /// </summary>
        private List<Area> objects;

        [SetUp]
        public void Initialize()
        {
            this.areaRepository = new Mock<IAreaRepository>();
            this.unitOfWork = new Mock<ITabledUnitOfWork>();
            this.objects = new List<Area>
            {
                new Area(1, 1, "Description1", 1)
                {
                    Id=1,
                    Command="TestCommand1"
                },
                new Area(2, 2, "Description2", 2)
                {
                    Id=2,
                    Command="TestCommand2"
                },
                new Area(3, 3, "Description3", 3)
                {
                    Id=3,
                    Command="TestCommand3"
                },
                new Area(4, 4, "Description4", 4)
                {
                    Id=4,
                    Command="TestCommand4"
                },
                new Area(5, 5, "Description5", 5)
                {
                    Id=5,
                    Command="TestCommand5"
                }
            };

            this.areaRepository.Setup(x => x.GetAll()).Returns(this.objects);
            this.unitOfWork.Setup(x => x.AreaRepository)
                .Returns(this.areaRepository.Object);
        }

        [Test]
        public async Task ReturnCorrectEnumFromRepository()
        {
            var repository = this.areaRepository.Object;
            var    areas = repository.GetAll();
            Assert.AreEqual(areas.Count(), 5);
        }

        [Test]
        public void ReturnCorrectEnumFromUnitOfWork()
        {
            var uow = this.unitOfWork.Object;
            var areas=uow.AreaRepository.GetAll();
            Assert.AreEqual(areas.Count(), 5);

        }
    }
}