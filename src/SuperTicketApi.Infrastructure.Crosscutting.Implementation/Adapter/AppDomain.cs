﻿namespace SuperTicketApi.Infrastructure.Crosscutting.Implementation.Adapter
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Microsoft.Extensions.DependencyModel;

    public class AppDomain
    {
        static AppDomain()
        {
            CurrentDomain = new AppDomain();
        }

        public static AppDomain CurrentDomain { get; private set; }

        public Assembly[] GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateCompilationLibrary(library))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }

            return assemblies.ToArray();
        }

        private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary)
        {
            return compilationLibrary.Name == "GurpsAssistant"
                   || compilationLibrary.Dependencies.Any(d => d.Name.StartsWith("GurpsAssistant"));
        }
    }
}
