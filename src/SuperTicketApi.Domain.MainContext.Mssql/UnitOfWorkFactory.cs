namespace SuperTicketApi.Domain.MainContext.Mssql
{
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string connectionString;

        public UnitOfWorkFactory(string connection)
        {
            connectionString = connection;
        }
        public IUnitOfWorkMssql Create()
        {
            var adoNetContext = new AdoNetUnitOfWork(connectionString, false);
            return new UnitOfWork(adoNetContext);
        }

        public IUnitOfWorkMssql CreateTransactional()
        {
            var adoNetContext = new AdoNetUnitOfWork(connectionString, true);
            return new UnitOfWork(adoNetContext);
        }
    }
}
