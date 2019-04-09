using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindModels
{
    [Table("Orders")]
    public class Order
    {
        //Primitive value types can be made null able by adding a ? after datatype
        //Strings have a null value by definition
            [Key]
            public int OrderID { get; set; }
            public int SalesRepID { get; set; }
            public string CustomerID { get; set; }
            public DateTime? OrderDate { get; set; }
            public DateTime? RequiredDate { get; set; }
            public decimal? Freight { get; set; }
            public string ShipName { get; set; }
            public string ShipAddress { get; set; }
            public string ShipCity { get; set; }
            public string ShipRegion { get; set; }
            public string ShipPostalCode { get; set; }
            public string ShipCountry { get; set; }
            public string Comments { get; set; }
        
    }
}
