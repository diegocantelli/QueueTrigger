using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunction
{
    //[StorageAccount("")]
    public static class Function1
    {
        [FunctionName("Function1")]
        //Connection -> configuração lida de local.settings.json
        public static void Run([QueueTrigger("personqueue")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
