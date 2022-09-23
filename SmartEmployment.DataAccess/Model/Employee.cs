using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class Employee : IEntityBase
	{
		public Employee()
		{
			Users = new HashSet<User>();
			Photos = new HashSet<Photo>();
			EmployeeTimesheetValues = new HashSet<EmployeeTimesheetValue>();
		}

		public int Id { get; set; }
		public int? PersonId { get; set; }
		public byte[] Version { get; set; }
		public int? CompanyId { get; set; }
		public string EmployeeCode { get; set; }
		public DateTime? TerminationDate { get; set; }
		public bool Deleted { get; set; }
		public int? HeadOfHierarchyFor { get; set; }
		public DateTime? LastReinstatementDate { get; set; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }
		public bool Draft { get; set; }

		public string About { get; set; }

		public virtual Person Person { get; set; }
		public virtual Company Company { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<Photo> Photos { get; set; }
		public virtual ICollection<EmployeeTimesheetValue> EmployeeTimesheetValues { get; set; }	
	}
}
