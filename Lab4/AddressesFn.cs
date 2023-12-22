using System.Net;
using System.Text.Json;
using CdvAzure.Service;
using Lab4.Database.Entities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CdvAzure.Functions
{
    public class AddressesFn
    {
        private readonly ILogger _logger;
        private readonly AddressesService addressesService;
        public AddressesFn(ILoggerFactory loggerFactory, AddressesService addressService)
        {
            _logger = loggerFactory.CreateLogger<AddressesFn>();
            this.addressesService = addressesService;
        }

        [Function("AddressesFn")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "delete", "put")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            switch(req.Method)
            {
                case "POST":
                    StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var addresses = JsonSerializer.Deserialize<AddressEntity>(json);
                    var res = addressesService.Add(addresses.City, addresses.Street, addresses.HomeNumber, addresses.ZipCode);
                    response.WriteAsJsonAsync(res);
                    break;
                case "PUT":
                    StreamReader putReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var putJson = putReader.ReadToEnd();
                    var putAddress = JsonSerializer.Deserialize<AddressEntity>(putJson);
                    var putRes = addressesService.Update(putAddress.AddressId, putAddress.City, putAddress.Street, putAddress.HomeNumber, putAddress.ZipCode);
                    response.WriteAsJsonAsync(putRes);
                    break;
                case "GET":
                    var address = addressesService.Get();
                    response.WriteAsJsonAsync(address);
                    break;
                case "DELETE":
                    StreamReader deleteReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                    var deleteJson = deleteReader.ReadToEnd();
                    var deleteAddress = JsonSerializer.Deserialize<AddressEntity>(deleteJson);
                    addressesService.Delete(deleteAddress.AddressId);
                    break;
            }
            return response;
        }
    }
}
