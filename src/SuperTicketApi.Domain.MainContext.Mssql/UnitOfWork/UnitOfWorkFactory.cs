namespace SuperTicketApi.Domain.MainContext.Mssql.UnitOfWork
{
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;

    internal class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string connectionString;

        public UnitOfWorkFactory(string connection)
        {
            this.connectionString = connection;
        }
        public IUnitOfWorkMssql Create()
        {
            var adoNetContext = new AdoNetUnitOfWork(this.connectionString, false);
            return new UnitOfWork(adoNetContext);
        }

        public IUnitOfWorkMssql CreateTransactional()
        {
            var adoNetContext = new AdoNetUnitOfWork(this.connectionString, true);
            return new UnitOfWork(adoNetContext);
        }
    }
}
