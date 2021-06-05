using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using SampleShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public async Task SendMessageAssync(Person personMessage, string queueName)
        {
            var connectionString = _configuration.GetConnectionString("AzureServiceBusConnection");
            QueueClient qClient = null;
            //QueueClient -> API de filas do Azure
            try
            {
                qClient = new QueueClient(connectionString, queueName);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            var msgBody = JsonSerializer.Serialize(personMessage);

            // enviando a msg para a fila
            await qClient.SendMessageAsync(msgBody.ToString());
        }
    }
}
