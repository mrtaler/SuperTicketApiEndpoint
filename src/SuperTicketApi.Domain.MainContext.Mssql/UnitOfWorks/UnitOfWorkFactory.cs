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
        public IUnitOfWork Create()
        {
            var adoNetContext = new AdoNetUnitOfWork(this.connectionString, false);
            return new UnitOfWork(adoNetContext);
        }

        public IUnitOfWork CreateTransactional()
        {
            var adoNetContext = new AdoNetUnitOfWork(this.connectionString, true);
            return new UnitOfWork(adoNetContext);
        }
    }
}
