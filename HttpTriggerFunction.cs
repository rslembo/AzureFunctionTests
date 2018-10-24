using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctionsProject.Models;

namespace AzureFunctionsProject
{
    public static class HttpTriggerFunction
    {
        [FunctionName("HttpTriggerFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "User")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<UserRequest>(requestBody);
            
            var name = user?.Name;
            var age = user?.Age;
            var isActive = user?.IsActive;

            return user != null
                ? (ActionResult)new OkObjectResult($"Hello, {name} {age} {isActive}")
                : new BadRequestObjectResult("Please pass a user in the request body");
        }
    }
}