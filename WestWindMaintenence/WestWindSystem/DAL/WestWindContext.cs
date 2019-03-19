using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using WestWindModels;

namespace WestWindSystem.DAL
{
    //Dal Class will inherit from ef's DbContextClass
    //In order to get all functionallity to map entity classes to database tables. Can think of this context class as being a virtual representation of db
    internal class WestWindContext : DbContext
    {
        #region Construcor
        public WestWindContext() : base("name=WWdb")
        {
            //Can programatically prevent default behaviour that EF uses which is to create db if it can't find it base on connection string
            Database.SetInitializer<WestWindContext>(null); //Prevent initialization
        }
        #endregion

        #region Properties
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion
    }
}
