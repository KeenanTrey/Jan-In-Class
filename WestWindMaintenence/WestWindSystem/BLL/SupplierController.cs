using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindModels;
using WestWindSystem.DAL;
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
