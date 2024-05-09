using Grpc.Core;

namespace GrpcService.Services
{
    public class CustomerService:Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public async override Task<CustomerDataModel> GetCustomerInfo(CustomerFindModel request, ServerCallContext context)
        {
            CustomerDataModel model = new CustomerDataModel();
            if(request.UserId == 1)
            {
                model.FirstName = "Khaled";
                model.LastName = "Nabil";
            }
            else
            {
                model.FirstName = "Shreif";
                model.LastName = "Soliman";
            }
            return model;
        }
        public override async Task GetAllCustomers(AllCustomerModel request, IServerStreamWriter<CustomerDataModel> responseStream, ServerCallContext context)
        {
            var customers = new List<CustomerDataModel>();

            var cus1 = new CustomerDataModel();
            cus1.FirstName = "Khaled1";
            cus1.LastName = "Nabil1";
            customers.Add(cus1);

            var cus2 = new CustomerDataModel();
            cus2.FirstName = "Khaled2";
            cus2.LastName = "Nabil2";
            customers.Add(cus2);


            var cus3 = new CustomerDataModel();
            cus3.FirstName = "Khaled3";
            cus3.LastName = "Nabil3";
            customers.Add(cus3);


            var cus4 = new CustomerDataModel();
            cus4.FirstName = "Khaled4";
            cus4.LastName = "Nabil4";
            customers.Add(cus4);


            foreach(var i in customers)
            {
                await responseStream.WriteAsync(i);
                //await Task.Delay(2000);
            }
        }
    }
}
