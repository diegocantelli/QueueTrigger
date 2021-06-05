using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using SampleShared.Interfaces;
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

        public async Task<string> PeekMessageAsync(string queueName)
        {
            var connectionString = _configuration.GetConnectionString("AzureServiceBusConnection");

            var qCliente = new QueueClient(connectionString, queueName, new QueueClientOptions 
            { 
                MessageEncoding = QueueMessageEncoding.Base64
            });

            if (!qCliente.Exists())
            {
                throw new Exception("A fila especificada não foi encontrada"); 
            }

            var msg = await qCliente.PeekMessageAsync();
            return Encoding.ASCII.GetString(msg.Value.Body);
        }

        public async Task SendMessageAssync(Person personMessage, string queueName)
        {
            var connectionString = _configuration.GetConnectionString("AzureServiceBusConnection");
            var qCliente = new QueueClient(connectionString, queueName, new QueueClientOptions
            {
                // convertendo para base64 para não dar erro no momento da leitura da msg
                MessageEncoding = QueueMessageEncoding.Base64
            });

            var msgBody = JsonSerializer.Serialize(personMessage);

            // enviando a msg para a fila
            await qCliente.SendMessageAsync(msgBody);
        }
    }
}
