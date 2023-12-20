// using System.Net;
// using System.Text.Json;
// using CdvAzure.Functions;
// using Microsoft.Azure.Functions.Worker;
// using Microsoft.Azure.Functions.Worker.Http;
// using Microsoft.Extensions.Logging;
// using Lab4.Database.Entities;

// namespace CdvAzure.Function
// {
//     public class AddressesFn
//     {
//         private readonly ILogger _logger;
//         private readonly AddressEntity addressEntity;
//         public AddressesFn(ILoggerFactory loggerFactory, AddressEntity addressEntity)
//         {
//             _logger = loggerFactory.CreateLogger<AddressesFn>();
//             this.addressEntity = addressEntity;
//         }

//         [Function("AddressesFn")]
//         public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
//         {
//             _logger.LogInformation("C# HTTP trigger function processed a request.");

//             var response = req.CreateResponse(HttpStatusCode.OK);

//             switch(req.Method)
//             {
//                 case "POST":
//                     StreamReader reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
//                     var json = reader.ReadToEnd();
//                     var addresses = JsonSerializer.Deserialize<Address>(json);
//                     var res = addressEntity.Add(addresses.City, addresses.Street, addresses.NumberOfHome, addresses.ZipCode);
//                     response.WriteAsJsonAsync(res);
//                     break;
//                 case "PUT":
//                     StreamReader putReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
//                     var putJson = putReader.ReadToEnd();
//                     var putAddress = JsonSerializer.Deserialize<Address>(putJson);
//                     var putRes = addressEntity.Update(putAddress.Id, putAddress.City, putAddress.Street, putAddress.NumberOfHome, putAddress.ZipCode);
//                     response.WriteAsJsonAsync(putRes);
//                     break;
//                 case "GET":
//                     var addresses = addressEntity.Get();
//                     response.WriteAsJsonAsync(addresses);
//                     break;
//                 case "DELETE":
//                     StreamReader deleteReader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
//                     var deleteJson = deleteReader.ReadToEnd();
//                     var deleteAddress = JsonSerializer.Deserialize<Address>(deleteJson);
//                     addressEntity.Delete(deleteAddress.Id);
//                     break;
//             }
//             return response;
//         }
//     }
//     internal class Address
//     {
//         public string City { get; internal set; }
//         public string Street { get; internal set; }
//         public int NumberOfHome { get; internal set; }
//         public int ZipCode { get; internal set; }
//     }
// }
