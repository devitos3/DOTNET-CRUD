using api2.Repository.interfaces;
using System.Data.SqlClient;
using api2.Models;

namespace api2.Repository
{
    public class CustomerRepo:ICustomerRepo
    {
        readonly string connectionString = "";
        public CustomerRepo()
        {
            connectionString = "Data Source=APINP-ELPTCKU92\\SQLEXPRESS;Initial Catalog=master;Persist Security Info=True;User ID=tap2023;Password=tap2023;Encrypt=False";
        }

        public Customer GetCustomerById(string id)
        {
            Customer c = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"SELECT CustomerId, CompanyName, Address, Contactname FROM Customers WHERE CustomerID = '{id}'";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    c = new Customer();
                    c.CustomerId = dr["CustomerId"].ToString();
                    c.CompanyName = dr["CompanyName"].ToString();
                    c.ContactName = dr["ContactName"].ToString();
                    c.Address = dr["Address"].ToString();
                }
            }
            return c;
        }


        public List<string> GetCustomers()
        {
            throw new NotImplementedException();
        }


        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerId, CompanyName, ContactName, Address) VALUES (@CustomerId, @CompanyName, @ContactName, @Address)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, Address = @Address WHERE CustomerId = @CustomerId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(string id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string deleteOrderDetailsQuery = "DELETE FROM [Order Details] WHERE OrderID IN (SELECT OrderID FROM Orders WHERE CustomerID = @Id)";
                SqlCommand deleteOrderDetailsCmd = con.CreateCommand();
                deleteOrderDetailsCmd.CommandText = deleteOrderDetailsQuery;
                deleteOrderDetailsCmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                deleteOrderDetailsCmd.ExecuteNonQuery();

                string deleteOrdersQuery = "DELETE FROM Orders WHERE CustomerID = @Id";
                SqlCommand deleteOrdersCmd = con.CreateCommand();
                deleteOrdersCmd.CommandText = deleteOrdersQuery;
                deleteOrdersCmd.Parameters.AddWithValue("@Id", id);
                deleteOrdersCmd.ExecuteNonQuery();

                string deleteCustomerQuery = "DELETE FROM Customers WHERE CustomerID = @Id";
                SqlCommand deleteCustomerCmd = con.CreateCommand();
                deleteCustomerCmd.CommandText = deleteCustomerQuery;
                deleteCustomerCmd.Parameters.AddWithValue("@Id", id);
                deleteCustomerCmd.ExecuteNonQuery();
            }
        }

       
        


    }
}