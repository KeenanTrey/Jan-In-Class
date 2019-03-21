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
        public int ProductID { get; set; } // int not null
        public string ProductName { get; set; } //nvarchar not null
        public int SupplierID { get; set; } // int not null
        public int CategoryID{ get; set; } // int not null
        public string QuantityPerUnit{ get; set; } // varchar not null
        public short? MinimumOrderQuantity { get; set; } //small int  null
        //? = shorthand nullable<short>
        public decimal UnitPrice { get; set; } //money not null
        public int UnitsOnOrder { get; set; } //int not null
        public bool IsDiscontinued { get; set; } //bit not null
       
    }

}
