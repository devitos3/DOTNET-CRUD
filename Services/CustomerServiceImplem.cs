using api2.Models;
using api2.Repository;
using api2.Repository.interfaces;
using api2.Services.Interfaces;


namespace api2.Services
{
    public class CustomerServicesImplem: ICustomerServices
    {
        ICustomerRepo _CustomerRepo;

        public CustomerServicesImplem(ICustomerRepo customerRepo)
        {
            _CustomerRepo = customerRepo;

        }
        public Customer GetCustomerById(string id)
        {
            return _CustomerRepo.GetCustomerById(id);
        }

        public List<string> GetCustomers()
        {
            throw new NotImplementedException();

        }

        public void CreateCustomer(Customer customer)
        {
            _CustomerRepo.CreateCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _CustomerRepo.UpdateCustomer(customer);
        }

        public void DeleteCustomer(string id)
        {
            _CustomerRepo.DeleteCustomer(id);
        }


       

    }
}
