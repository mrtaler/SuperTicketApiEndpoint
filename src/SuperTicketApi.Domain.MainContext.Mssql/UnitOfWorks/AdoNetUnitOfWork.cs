namespace SuperTicketApi.Domain.MainContext.Mssql.UnitOfWorks
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    using SuperTicketApi.Domain.Seedwork;

    internal class AdoNetUnitOfWork : INetUnitOfWork, IUnitOfWork
    {
        IDbConnection connection;
        IDbTransaction transaction;
        bool isTransactional;


        public AdoNetUnitOfWork(string connectionString, bool isTransactional)
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
}