using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Model
{
    public class EmployeeServiceModel
    {
        public int Id { get; set; }
        [DisplayName("Employee Code")]
        public string EmployeeCode { get; set; }
        [DisplayName("Employee Company Code")]
        public string CompanyCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DisplayName("Employee Email")]
        public string EmployeeEmail { get; set; }
        public DateTime Birthdate { get; set; }
        [DisplayName("Employee Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("Employee Termination Date")]
        public DateTime? TerminationDate { get; set; }  
    }
}
