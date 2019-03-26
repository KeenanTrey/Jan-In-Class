using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindModels;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    public class SupplierController
    {
        //Used to help with Crud maintenence
        public List<Supplier> ListSuppliers()
        {
            //Make use of virtual database class
            using (var context = new WestWindContext())
            {
                return context.Suppliers.ToList();
            }
        }

        public List<Country> ListCountries()
        {
            using (var context = new WestWindContext())
            {
                string sql = "SELECT DISTINCT Country AS 'Name' FROM Suppliers ORDER BY Country";
                //.Database property of dbcontext object gives more sirect accesss to the database. W/ this we can call methods such as .execute or .sqlQuery
                var result = context.Database.SqlQuery<Country>(sql);
                return result.ToList();
            }
        }

        public Supplier GetSupplier(int id)
        {
            using (var context = new WestWindContext())
            {
                //.Find() method will look up the object based on primary key
                return context.Suppliers.Find(id);
            }
        }
    }
}
