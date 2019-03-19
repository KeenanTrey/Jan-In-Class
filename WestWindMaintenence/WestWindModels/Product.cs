using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //For [Key]
using System.ComponentModel.DataAnnotations.Schema; // For [Table]
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindModels
{
    //We annotate classes or other iems in code to give extra information or metadata that can be used by VS tooling and other libraries to do "magic"
    [Table("Products", Schema = "dbo")] //Identify the table name and schema 
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID{ get; set; }
        public string QuantityPerUnit{ get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsOnOrder { get; set; }
        public bool IsDiscontinued { get; set; }
       
    }

}
