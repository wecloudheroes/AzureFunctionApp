using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WatchPortalFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }

        [FunctionName("FuncAdd")]
        public static async Task<IActionResult> addrun(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string num1 = req.Query["num1"];
            string num2 = req.Query["num2"];

            num1 = num1 + num2;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            num1 = num1 ?? data?.num1;

            return num1 != null
                ? (ActionResult)new OkObjectResult($"Hello Addition of Two number is  {num1}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
        [FunctionName("Funcsquare")]
        public static async Task<IActionResult> square(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string num = req.Query["num"];
          

                double square = Convert.ToDouble(num) * Convert.ToDouble(num);

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                num = num ?? data?.square;

                return num != null
                    ? (ActionResult)new OkObjectResult($"Hello Square of { num } is  {square}")
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
        }
    //public static class Function2
    //{
    //    [FunctionName("Function2")]
    //    public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "xxxxxxxxxxxxxxxxxxxxxxx")]Stream myBlob, string name, ILogger log)
    //    {
    //        log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
    //    }
    //}
}
