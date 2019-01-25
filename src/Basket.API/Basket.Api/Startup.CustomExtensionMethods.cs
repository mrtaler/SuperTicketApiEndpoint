using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Basket.Api
{
   
        /*    private void RegisterEventBus(IServiceCollection services)
            {
                var subscriptionClientName = Configuration["SubscriptionClientName"];

                if (Configuration.GetValue<bool>("AzureServiceBusEnabled"))
                {
                    services.AddSingleton<IEventBus, EventBusServiceBus>(sp =>
                    {
                        var serviceBusPersisterConnection = sp.GetRequiredService<IServiceBusPersisterConnection>();
                        var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                        var logger = sp.GetRequiredService<ILogger<EventBusServiceBus>>();
                        var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                        return new EventBusServiceBus(serviceBusPersisterConnection, logger,
                            eventBusSubcriptionsManager, subscriptionClientName, iLifetimeScope);
                    });
                }
                else
                {
                    services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
                    {
                        var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                        var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                        var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                        var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                        var retryCount = 5;
                        if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                        {
                            retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                        }

                        return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
                    });
                }

                services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

                services.AddTransient<ProductPriceChangedIntegrationEventHandler>();
                services.AddTransient<OrderStartedIntegrationEventHandler>();
            }*/

        /*   private void ConfigureEventBus(IApplicationBuilder app)
           {
               var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

               eventBus.Subscribe<ProductPriceChangedIntegrationEvent, ProductPriceChangedIntegrationEventHandler>();
               eventBus.Subscribe<OrderStartedIntegrationEvent, OrderStartedIntegrationEventHandler>();
           }*/

        

    
}
