namespace SuperTicketApi.Infrastructure.Crosscutting.Tests
{
    using System;

    using AutoMapper;

    using SuperTicketApi.Infrastructure.Crosscutting.Tests.Classes;

    public class AutomapperInitializer : IDisposable
    {
        public AutomapperInitializer()
        {
            //Arrange
            Mapper.Initialize(cfg => cfg.AddProfile(new TypeAdapterProfile()));
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
