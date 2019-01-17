namespace SuperTicketApi.Domain.NUnitTests
{
    using Moq;
    using NUnit.Framework;
    using SuperTicketApi.Domain.MainContext.DTO;
    using SuperTicketApi.Domain.MainContext.DTO.IndividualRepositories;
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.Repositories;
    using SuperTicketApi.Domain.Seedwork;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

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

        protected Mock<IDataReader> datareader = new Mock<IDataReader>();

        /// <summary>
        /// The initialize.
        /// </summary>
        [SetUp]
        public void Initialize()
        {
            this.areaRepository = new Mock<IAreaRepository>();
            this.unitOfWork = new Mock<ITabledUnitOfWork>();
            this.objects = new List<Area>
            {
                new Area(1, 1, "Description1", 1) { Id = 1, Command = "TestCommand1" },
                new Area(2, 2, "Description2", 2) { Id = 2, Command = "TestCommand2" },
                new Area(3, 3, "Description3", 3) { Id = 3, Command = "TestCommand3" },
                new Area(4, 4, "Description4", 4) { Id = 4, Command = "TestCommand4" },
                new Area(5, 5, "Description5", 5) { Id = 5, Command = "TestCommand5" }
            };

            this.areaRepository.Setup(x => x.GetAll()).Returns(this.objects);
            this.unitOfWork.Setup(x => x.AreaRepository)
                .Returns(this.areaRepository.Object);
        }

        /// <summary>
        /// The return correct enum from repository.
        /// </summary>
        [Test]
        public void ReturnCorrectEnumFromRepository()
        {
            var repository = this.areaRepository.Object;
            var areas = repository.GetAll();
            Assert.AreEqual(areas.Count(), 5);
        }

        /// <summary>
        /// The return correct enum from unit of work.
        /// </summary>
        [Test]
        public void ReturnCorrectEnumFromUnitOfWork()
        {
            var uow = this.unitOfWork.Object;
            var areas = uow.AreaRepository.GetAll();
            Assert.AreEqual(areas.Count(), 5);

        }

        [Test]
        public void retSql()
        {
            datareader.Setup(x => x.Read()).Returns(true);

            datareader.Setup(x => x["AreaId"]).Returns(1);
            datareader.Setup(x => x["LayoutId"]).Returns(1);
            datareader.Setup(x => x["Description"]).Returns("TestDescription1");
            datareader.Setup(x => x["CoordX"]).Returns(1);
            datareader.Setup(x => x["CoordY"]).Returns(1);

            var gr = new AreaRepository(It.IsAny<string>(), It.IsAny<ISqlHelper>()).Mapping(datareader.Object);

            Assert.AreEqual(gr.Id, 1);
        }
    }
}