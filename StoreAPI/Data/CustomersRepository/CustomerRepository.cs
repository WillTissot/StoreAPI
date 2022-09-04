using AutoMapper.Internal.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Data.Context;
using StoreAPI.Models.User;

namespace StoreAPI.Data.CustomersRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            _context.Customers.Remove(customer);
        }

        public async Task<Customer> GetCustomer(int id)
        {

            var connString = this._context.Database.GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var query = $"EXEC GetCustomer @ID = {id}";

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                var typeCustomer = typeof(Customer);
                Customer customer = (Customer)Activator.CreateInstance(typeCustomer);
                var typeAddress = typeof(Address);
                Address address = (Address)Activator.CreateInstance(typeAddress);

                var phoneNumbers = new List<PhoneNumber>();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        foreach (var prop in typeCustomer.GetProperties())
                        {
                            if (prop.Name.Equals("Address"))
                                break;
                            var propType = prop.PropertyType;
                            prop.SetValue(customer, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                        }
                    }


                    await reader.NextResultAsync();


                    while (await reader.ReadAsync())
                    {

                        foreach (var prop in typeAddress.GetProperties())
                        {
                            var propType = prop.PropertyType;
                            prop.SetValue(address, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                            if (prop.Name.Equals("StreetAddress"))
                                break;
                        }
                    }

                   
                    await reader.NextResultAsync();


                    while (await reader.ReadAsync())
                    {
                        var typePhoneNumber = typeof(PhoneNumber);
                        PhoneNumber phoneNumber = (PhoneNumber)Activator.CreateInstance(typePhoneNumber);

                        foreach (var prop in typePhoneNumber.GetProperties())
                        {
                            var propType = prop.PropertyType;
                            prop.SetValue(phoneNumber, Convert.ChangeType(reader[prop.Name].ToString(), propType));
                            if (prop.Name.Equals("PersonId"))
                                break;
                        }

                        phoneNumbers.Add(phoneNumber);


                    }


                    reader.Close();

                    customer.Address = new Address();
                    customer.Address.StreetAddress = address.StreetAddress;
                    customer.Address.State = address.State;
                    customer.Address.City = address.City;
                    customer.Address.Id = address.Id;
                    customer.PhoneNumbers = phoneNumbers;

                    return customer;

                }
                return null;
               
            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(c => c.PhoneNumbers).Include(c => c.Address).ToList();
        }
        public bool CustomerExists(int id)
        {
            var customer = _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if(customer == null)
            {
                return false;
            }
            return true;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }


    }
}
