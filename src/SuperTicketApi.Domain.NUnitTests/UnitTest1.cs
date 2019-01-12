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
        }
    }
}