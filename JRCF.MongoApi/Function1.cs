using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JRCF.MongoApi
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
             [CosmosDB(
                databaseName: "NomeDaBase", //Alterar
                collectionName: "NomeDaColecao",//Alterar
                ConnectionStringSetting = "CosmosDBConnection")]
                IAsyncCollector<RequestModel> collection,
            ILogger log
)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            RequestModel data = JsonConvert.DeserializeObject<RequestModel>(requestBody);


            await collection.AddAsync(data);

            return new OkObjectResult(data);
        }
    }
}
