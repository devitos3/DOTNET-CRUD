using api2.Models;

namespace api2.Repository.interfaces
{
    public interface ICustomerRepo
    {
        List<string> GetCustomers();
        Customer GetCustomerById(string id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
   

    }
}
