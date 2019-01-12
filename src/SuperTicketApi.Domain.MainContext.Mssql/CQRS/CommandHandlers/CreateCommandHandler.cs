namespace SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers
{
    using MediatR;
    using SuperTicketApi.Domain.MainContext.Command;
    using SuperTicketApi.Domain.MainContext.Command.CreateCommands;
    using SuperTicketApi.Domain.MainContext.Mssql.CQRS.CommandHandlers.General;
    using SuperTicketApi.Domain.MainContext.Mssql.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The create command handler.
    /// </summary>
    internal class CreateCommandHandler
        : BaseCommandHandler,
          IRequestHandler<CreateAreaCommand, CommandResponse>,
          IRequestHandler<CreateEventAreaCommand, CommandResponse>,
          IRequestHandler<CreateEventCommand, CommandResponse>,
          IRequestHandler<CreateEventSeatCommand, CommandResponse>,
          IRequestHandler<CreateLayoutCommand, CommandResponse>,
          IRequestHandler<CreateSeatCommand, CommandResponse>,
          IRequestHandler<CreateVenueCommand, CommandResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCommandHandler"/> class.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="mediatr">
        /// The mediatr.
        /// </param>
        public CreateCommandHandler(
            IUnitOfWorkFactory factory, IMediator mediatr)
            : base(factory, mediatr)
        {
        }

        #region Implementation of IRequestHandler<in CreateAreaCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(
            CreateAreaCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Area Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion

        #region Implementation of IRequestHandler<in CreateEventAreaCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateEventAreaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in EventArea Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion

        #region Implementation of IRequestHandler<in CreateEventCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Event Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion

        #region Implementation of IRequestHandler<in CreateEventSeatCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateEventSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in EventSeat Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion

        #region Implementation of IRequestHandler<in CreateLayoutCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateLayoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Layout Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion

        #region Implementation of IRequestHandler<in CreateSeatCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Seat Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion

        #region Implementation of IRequestHandler<in CreateVenueCommand,CommandResponse>

        /// <inheritdoc />
        public async Task<CommandResponse> Handle(CreateVenueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (this.Command.Connection.State != ConnectionState.Open)
                {
                    return new CommandResponse
                    {
                        Message = "One or more validation errors occurred.",
                        DbValidationErrors = new List<string> { "connection was closed" }
                    };
                }

                var newItemId = this.GetSqlParameter(
                    parameterName: "AddedId",  // this returned value
                    parameterDirection: ParameterDirection.Output,
                    sqlDbType: SqlDbType.Int,
                    size: 1);

                var paramList = this.GetSqlParameters(request, newItemId).ToList();

                this.ExecuteSpWithReader(
                     request.Command,
                     this.Command,
                     paramList);

                // this.Logger.Info($"Change in db table {typeof(Area).Name} : {returnValue} entities");
                var retId = (int)newItemId.Value;
                var retResp = new CommandResponse
                {
                    IsSuccess = true,
                    Message = "new entity in Venue Table was added",
                    Object = retId
                };
                return await Task.FromResult(retResp);
            }
            catch (Exception ex)
            {
                var ret = new CommandResponse { Message = ex.Message };
                return await Task.FromResult(ret);
            }
        }

        #endregion
    }
}
