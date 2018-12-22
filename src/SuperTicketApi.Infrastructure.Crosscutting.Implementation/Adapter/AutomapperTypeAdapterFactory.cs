namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter
{
    using System;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    using SuperTicketApi.Infrastructure.Crosscutting.Adapter;

    /// <summary>
    /// The automapper type adapter factory.
    /// </summary>
    public class AutomapperTypeAdapterFactory
       : ITypeAdapterFactory
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomapperTypeAdapterFactory"/> class. 
        /// <see cref="Create"/> a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            // scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                                    .GetAssemblies()
                                    .Where(x => x.GetName().FullName.Contains("SuperTicketApi"))
                                    .SelectMany(a => a.GetTypes())
                                    .Where(t => t.GetTypeInfo().BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2"
                        && item.FullName != "AutoMapper.MapperConfiguration+NamedProfile")
                    {
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                    }
                }
            });
        }

        #endregion

        #region ITypeAdapterFactory Members

        /// <inheritdoc />
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter();
        }

        #endregion
    }
}
