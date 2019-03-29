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
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string JobTitle { get; set; }
        public int? ReportsTo { get; set; }
        public DateTime HireDate { get; set; }
        public string OfficePhone { get; set; }
        public string Extension { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        // varbinary is an array of bytes. Arrays are by nature reference types
        public byte[] Photo { get; set; } //varbinary null

        private string _PhotoMimeType;

        public string PhotoMimeType
        {
            get { return _PhotoMimeType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _PhotoMimeType = null;
                }
                else
                {
                    _PhotoMimeType = value.ToLower();
                }
            }
        }
           
        public string Notes { get; set; }
        public bool? Active { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool OnLeave { get; set; }
        public string LeaveReason { get; set; }
        public DateTime? ReturnDate { get; set; }

        [NotMapped] //does not correspond with vcolumn in table
        public string FullName //find value based on other properties
        { get { return $"{TitleOfCourtesy} {FirstName} {LastName}".Trim(); } }

        [NotMapped]
        public string FormalName
        { get { return $"{LastName}, {FirstName}"; } }

    }
}
