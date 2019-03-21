using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWindModels
{
    [Table("Employees", Schema = "dbo")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string JobTitle { get; set; }
        public string ReportsTo { get; set; }
        public DateTime HireDate { get; set; }
        public int OfficePhone { get; set; }
        public int Extension { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Photo { get; set; }
        public string PhotoMimeType { get; set; }
        public string Notes { get; set; }
        public string Active { get; set; }
        public DateTime TerminationDate { get; set; }
        public string OnLeave { get; set; }
        public string LeaveReason { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
