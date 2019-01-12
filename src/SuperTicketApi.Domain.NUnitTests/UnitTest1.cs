namespace SuperTicketApi.Domain.NUnitTests
{
    using MediatR;
    using Moq;
    using NUnit.Framework;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.QueryHandlers;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Threading.Tasks;

    using SuperTicketApi.Domain.MainContext.Queries.GetListOfDomainEntity;

    internal class UnitOfWorkFactoryForTest : IUnitOfWorkFactory
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory"/> class.
        /// </summary>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public UnitOfWorkFactoryForTest(string connection)
        {
            this.connectionString = connection;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="INetUnitOfWork"/>.
        /// </returns>
        public INetUnitOfWork Create()
        {
            var adoNetContext = new AdoNetUnitOfWorkForTest(this.connectionString, false);
            return adoNetContext;
        }

        /// <summary>
        /// The create transactional.
        /// </summary>
        /// <returns>
        /// The <see cref="INetUnitOfWork"/>.
        /// </returns>
        public INetUnitOfWork CreateTransactional()
        {
            var adoNetContext = new AdoNetUnitOfWorkForTest(this.connectionString, true);
            return adoNetContext;
        }
    }


    /// <summary>
    /// The ado net unit of work.
    /// </summary>
    internal class AdoNetUnitOfWorkForTest : INetUnitOfWork, IUnitOfWork
    {
        /// <summary>
        /// The is transactional.
        /// </summary>
        private readonly bool isTransactional;

        /// <summary>
        /// The transaction.
        /// </summary>
        private IDbTransaction transaction;

        /// <summary>
        /// The connection.
        /// </summary>
        private IDbConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoNetUnitOfWork"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The connection string.
        /// </param>
        /// <param name="isTransactional">
        /// The is transactional.
        /// </param>
        public AdoNetUnitOfWorkForTest(string connectionString, bool isTransactional)
        {
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
            this.isTransactional = isTransactional;
        }

        /// <inheritdoc />
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

        /// <summary>
        /// The save change.
        /// </summary>
        /// <exception cref="InvalidOperationException">Transaction have already been commited
        /// </exception>
        public void SaveChange()
        {
            if (this.connection == null)
            {
                throw new InvalidOperationException("Transaction have already been commited. Check your transaction handling.");
            }

            this.transaction.Commit();
            this.transaction = null;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void Commit()
        {
            this.SaveChange();
        }
    }



    public class GetAreaAsIEnumerableQueryHandlerShould
    {
        private IMediator Mediator => null;

        /* [SetUp]
         public void GetAreaAsIEnumerableQueryHandlerShould()
         {
         }
         */
        public GetAreaAsIEnumerableQueryHandlerShould()
        {
        }

        [Test]
        public async Task ReturnCorrectEnum()
        {

        }

        [Test]
        public void EmptyTable()
        {
            var mock = new MockRepository(MockBehavior.Default);
            var command = mock.OneOf<IDbCommand>();
            var connection = mock.OneOf<IDbConnection>(_ => _.CreateCommand() == command);
            var factory = mock.OneOf<IUnitOfWorkFactory>(_ => _.Create() == connection);

            var subject = new GetQueryAsIEnumerableQueryHandler(factory, Mediator);
            var schema = "dbo";
            var tableName = "TestTable";
            CancellationTokenSource cts = new CancellationTokenSource();
            subject.Handle(new GetAreaAsIEnumerableQuery(), cts.Token);

            Mock.Get(command).Verify(_ => _.ExecuteNonQuery(), Times.Once());
        }
    }
}