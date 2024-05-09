using Grpc.Core;
using Grpc.Net.Client;
using GrpcClientApp;

Console.WriteLine("Hello, World!");

var channel = GrpcChannel.ForAddress("http://localhost:5000");

var customerClient = new Customer.CustomerClient(channel);
var result = await customerClient.GetCustomerInfoAsync(new CustomerFindModel
{
    UserId = 1
}); 
Console.WriteLine($"{result.FirstName} + {result.LastName }");

var allCustomers = customerClient.GetAllCustomers(new AllCustomerModel());

await foreach(var i in allCustomers.ResponseStream.ReadAllAsync())
{
    Console.WriteLine($"{i.FirstName} {i.LastName} \n");
}