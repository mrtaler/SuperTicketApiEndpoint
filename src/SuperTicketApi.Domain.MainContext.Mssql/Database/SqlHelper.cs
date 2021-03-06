﻿using System;
using System.Collections.Generic;

namespace SuperTicketApi.Domain.MainContext.Mssql.Database
{
    using SuperTicketApi.Domain.Seedwork;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    /// <summary>
    /// The sql helper.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class SqlHelper<T> : ISqlHelper where T : DbConnection
    {
        public IDataReader ExecuteReader(
            IDbConnection connection,
            string commandText,
            params SqlParameter[] parameters)
        {
            return SqlHelper<T>.CreateDbCommand(
                    connection,
                    commandText,
                    new CommandType?(),
                    (IEnumerable<SqlParameter>)parameters).ExecuteReader();
        }

        public IDataReader ExecuteReader(
            IDbConnection connection,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return SqlHelper<T>.CreateDbCommand(
                connection,
                commandText,
                new CommandType?(commandType),
                (IEnumerable<SqlParameter>)parameters).ExecuteReader();
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            T instance = (T)Activator.CreateInstance(typeof(T), new object[1] { (object)connectionString });
            instance.Open();
            return (IDbConnection)instance;
        }

        public int ExecuteNonQuery(
            IDbConnection connection, 
            string commandText,
            params SqlParameter[] parameters)
        {
            return SqlHelper<T>.CreateDbCommand(
                connection, 
                commandText, 
                new CommandType?(),
                (IEnumerable<SqlParameter>)parameters).ExecuteNonQuery();
        }

        public Td ExecuteScalar<Td>(
            IDbConnection connection,
            string commandText, 
            params SqlParameter[] parameters)
        {
            return (Td)SqlHelper<T>.CreateDbCommand(
                connection, 
                commandText,
                new CommandType?(), 
                (IEnumerable<SqlParameter>)parameters).ExecuteScalar();
        }

        public int ExecuteNonQuery(
            IDbConnection connection,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return SqlHelper<T>.CreateDbCommand(
                connection,
                commandText, 
                new CommandType?(commandType),
                (IEnumerable<SqlParameter>)parameters).ExecuteNonQuery();
        }

        private static IDbCommand CreateDbCommand(
            IDbConnection connection, 
            string commandText,
            CommandType? commandType, 
            IEnumerable<SqlParameter> parameters)
        {
            IDbCommand command = connection.CreateCommand();
            command.CommandText = commandText;
            IDbCommand dataBaseCommand = command;
            CommandType? nullable = commandType;

            int num = nullable.HasValue ? (int)nullable.GetValueOrDefault() : 1;
            dataBaseCommand.CommandType = (CommandType)num;

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            /*   foreach (Parameter parameter1 in parameters)
               {
                   IDbDataParameter parameter2 = command.CreateParameter();
                   parameter2.ParameterName = parameter1.Key;
                   parameter2.Value = parameter1.Value ?? (object)DBNull.Value;
                   command.Parameters.Add((object)parameter2);
               }
               */
            return command;
        }
    }
}
