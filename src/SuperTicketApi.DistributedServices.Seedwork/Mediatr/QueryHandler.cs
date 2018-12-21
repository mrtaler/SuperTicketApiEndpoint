namespace SuperTicketApi.DistributedServices.Seedwork.Mediatr
{
    // https://docs.microsoft.com/ru-ru/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1

   /* public class QueryHandler : IRequestHandler<BaseQuery, (TechnicalLevelDto, string, int)>
    {
        private ITechnicalLevelAppService tlServ;

        public QueryHandler(ITechnicalLevelAppService tlServ)
        {
            this.tlServ = tlServ;
        }

        public Task<(TechnicalLevelDto, string, int)> Handle(BaseQuery request, CancellationToken cancellationToken)
        {
            var r1 = this.tlServ.GetAllItems().First();
            var r2 = (r1, r1.Name, r1.TechnicalLevelId);
            return Task.FromResult(r2);
        }
    }*/
}
