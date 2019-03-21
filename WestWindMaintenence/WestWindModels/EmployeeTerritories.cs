using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindModels
{
    [Table("EmployeeTerritories", Schema = "dbo")]
    public class EmployeeTerritories
    {
        [Key]
        public int EmployeeID { get; set; }
        public int TerritoryID { get; set; }
    }
}
