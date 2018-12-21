namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Localization
{
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;

    public class ResourcesManagerFactory : ILocalizationFactory
    {
        public ILocalization Create()
        {
            return new ResourcesManager();
        }
    }
}
