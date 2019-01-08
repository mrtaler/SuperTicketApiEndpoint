using NUnit.Framework;

namespace Tests
{
    using SuperTicketApi.Domain.MainContext.DTO.Models;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers;
    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;
    using SuperTicketApi.Domain.Seedwork;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks;

    internal class AdoNetUnitOfWorkTest : INetUnitOfWork, IUnitOfWork
    {
        IDbConnection connection;
        IDbTransaction transaction;
        bool isTransactional;

        public AdoNetUnitOfWorkTest(string connectionString, bool isTransactional)
        {
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
            this.isTransactional = isTransactional;
        }

        public IDbCommand CreateCommand()
        {
            IDbCommand command = this.connection.CreateCommand();
            if (this.isTransactional && this.transaction == null)
            {
                this.transaction = this.connection.BeginTransaction();
                command.Transaction = this.transaction;
            }

            if (this.isTransactional && this.transaction != null)
            {
                command.Transaction = this.transaction;
            }

            return command;
        }

        public void SaveChange()
        {
            if (this.connection == null)
            {
                throw new InvalidOperationException("Transaction have already been commited. Check your transaction handling.");
            }

            this.transaction.Commit();
            this.transaction = null;
        }

        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction = null;
            }

            if (this.connection != null)
            {
                this.connection.Close();
                this.connection = null;
            }
        }

        public void Commit()
        {
            this.SaveChange();
        }
    }

    internal class UnitOfWorkFactoryTest : IUnitOfWorkFactory
    {
        private readonly string connectionString;

        public UnitOfWorkFactoryTest(string connection)
        {
            this.connectionString = connection;
        }
        public INetUnitOfWork Create()
        {
            var adoNetContext = new AdoNetUnitOfWorkTest(this.connectionString, false);
            return adoNetContext;
        }

        public INetUnitOfWork CreateTransactional()
        {
            var adoNetContext = new AdoNetUnitOfWorkTest(this.connectionString, true);
            return adoNetContext;
        }
    }


    public class GetAreaAsIEnumerableQueryHandlerShould
    {
        /* [SetUp]
         public void GetAreaAsIEnumerableQueryHandlerShould()
         {
         }
         */
        private readonly GetAreaAsIEnumerableQuery message;
        private readonly Area area;
        private readonly GetQueryAsIEnumerableQueryHandler sut;
        private IMediator Mediator=>null;

        public GetAreaAsIEnumerableQueryHandlerShould()
        {
            this.message = new GetAreaAsIEnumerableQuery();
            this.area = new Area()
            {
                LayoutId = 1,
                Description = "Test1",
                CoordX = 1,
                CoordY = 1
            };
            sut = new GetQueryAsIEnumerableQueryHandler(new UnitOfWorkFactoryTest(@"Data Source=EPBYGOMW0360\EPBYGOMW0360;Database=SuperTicketApiMssqlTests;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;"), Mediator);
        }

        [Test]
        public async Task ReturnCorrectEnum()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var result = await sut.Handle(message, cts.Token);
            Assert.NotNull(result);
        }
    }
}