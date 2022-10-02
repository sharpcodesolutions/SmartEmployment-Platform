using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Company Code")]
        public string CompanyCode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DisplayName("Email")]
        public string EmployeeEmail { get; set; }
		[DataType(DataType.Date)]
		public DateTime Birthdate { get; set; }
		[DataType(DataType.Date)]
		[DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
		[DataType(DataType.Date)]
		[DisplayName("Termination Date")]
        public DateTime? TerminationDate { get; set; }  
    }
}
