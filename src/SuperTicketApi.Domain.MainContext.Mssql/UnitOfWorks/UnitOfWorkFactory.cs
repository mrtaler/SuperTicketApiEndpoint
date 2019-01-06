namespace SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks
{
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using SuperTicketApi.Domain.Seedwork;

    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string connectionString;

        public UnitOfWorkFactory(string connection)
        {
            this.connectionString = connection;
        }
        public INetUnitOfWork Create()
        {
            var adoNetContext = new AdoNetUnitOfWork(this.connectionString, false);
            return adoNetContext;
        }

        public INetUnitOfWork CreateTransactional()
        {
            var adoNetContext = new AdoNetUnitOfWork(this.connectionString, true);
            return adoNetContext;
        }
    }
}
