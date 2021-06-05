using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AzureFunction.Infrastructure
{
    public sealed class DIContainer
    {
        private static readonly IServiceProvider _instance;
        private static IServiceProvider Instance => _instance;

        static DIContainer() { }

        private DIContainer() { }

        private static IServiceProvider Build()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return services.BuildServiceProvider();
        }

    }
}
