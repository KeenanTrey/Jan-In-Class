using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindModels;
using WestWindSystem.DAL;
using WestWindSystem.DataModels;

namespace WestWindSystem.BLL
{
    [DataObject] //From system.ComponentModel namespace
    public class SupplierController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
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

        public int AddSupplier(Supplier item)
        {
           using(var context = new WestWindContext())
            {
                var added = context.Suppliers.Add(item);
                context.SaveChanges();
                //After saving changes, local context object syncs with newly add supplierID that was generated from table's identity constraints
                return added.SupplierID;
            }
        }

        public void UpdateSupplier(Supplier item)
        {
            using (var context = new WestWindContext())
            {
                //The following approach will update entire suppplier object in database
               
                DbEntityEntry<Supplier> existing = context.Entry(item);
                //treat whole entity (all propoerties) as being modified
                existing.State = System.Data.Entity.EntityState.Modified;
                //Save
                context.SaveChanges();
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            using (var context = new WestWindContext())
            {
                Supplier found = context.Suppliers.Find(supplierId);
                context.Suppliers.Remove(found);
                context.SaveChanges();
            }
        }

        //Overloaded method that chains delete supplier 
        public void DeleteSupplier(Supplier item)
        {
            DeleteSupplier(item.SupplierID);
        }
    }
}
