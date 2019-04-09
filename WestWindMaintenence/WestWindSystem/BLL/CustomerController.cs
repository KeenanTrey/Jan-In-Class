using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using WestWindModels;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class CustomerController
    {
        public List<Customer> ListCustomers()
        {
            using (var context = new WestWindContext())
            {
                return context.Customers.ToList();
            }
        }

        public List<Customer> GetCustomersByCompanyName(string partialCompanyName)
        {
            using (var context = new WestWindContext())
            {
                string sql = "EXEC Customers_GetByPartialCompanyName @name";
                //Call the context classes .database object to run sql query w/ expected return type

                //@name is a named parameter and we prevent sql injection attacks by constructiong an sql parameter object w/ value they want to supply
                var param = new SqlParameter("name", partialCompanyName);
                DbRawSqlQuery<Customer> result = context.Database.SqlQuery<Customer>(sql, param);
                //RowType  //@0

                //When debugging, another variable can be useful to hold result of .tolist
                var finalResult = result.ToList();

                return result.ToList();
            }
        }

        public List<Customer> GetCustomersByContact(string partialContactName)
        {
            using (var context = new WestWindContext())
            {
                var result = context.Database.SqlQuery<Customer>("EXEC Customers_GetByPartialContactName @0", partialContactName);
                return result.ToList();
            }
        }
    }
}
