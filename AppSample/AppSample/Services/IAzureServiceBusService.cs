using SampleShared.Interfaces;
using SampleShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSample.Services
{
    public interface IAzureServiceBusService
    {
        Task SendMessageAssync(Person personMessage, string queueName);
        Task<string> PeekMessageAsync(string queueName);
    }
}
