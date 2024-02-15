using api2.Models;


namespace api2.Services.Interfaces
{
    public interface ICustomerServices
    {
        

        List<string> GetCustomers();
       Customer GetCustomerById(string id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
      
     

    }
}
