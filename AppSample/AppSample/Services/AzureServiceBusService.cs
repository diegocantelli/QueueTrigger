using Microsoft.Extensions.Configuration;
using SampleShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSample.Services
{
    public class AzureServiceBusService : IAzureServiceBusService
    {
        //IConfiguration -> utilizada para termos acesso ao appsettings
        //O framework já fornece a injeção de dependência por padrão, não é necessário add no startup
        private readonly IConfiguration _configuration;

        public AzureServiceBusService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendMessageAssync(Person personMessage, string queueName)
        {
            throw new NotImplementedException();
        }
    }
}
