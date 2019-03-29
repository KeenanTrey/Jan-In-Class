using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindModels;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class OrderController
    {
        public List<Order> ListOrders()
        {
            using (var context = new WestWindContext())
            {
                return context.Orders.ToList();
            }
        }

        public List<Order> ListOrders (string byCustomerID)
        {
            using (var context = new WestWindContext())
            {
                string sql = "Exec Orders_GetByCustomer @0";
                var result = context.Database.SqlQuery<Order>(sql, byCustomerID);
                return result.ToList();
            } 
        }
    }
}
