using Microsoft.Azure.ServiceBus;
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

            //QueueClient -> API de filas do Azure
            var qClient = new QueueClient(connectionString, queueName);

            var msgBody = JsonSerializer.Serialize(personMessage);

            //Message -> API de msgs para serem enviadas à fila do azure
            var msgByte = new Message(Encoding.UTF8.GetBytes(msgBody));

            // enviando a msg para a fila
            await qClient.SendAsync(msgByte);
        }
    }
}
