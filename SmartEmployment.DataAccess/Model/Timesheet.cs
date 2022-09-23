using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class Timesheet
	{
		public Timesheet()
		{
			EmployeeTimesheetValues = new HashSet<EmployeeTimesheetValue>();
		}
		public int Id { get; set; }
		public int PayRunId { get; set; }
		public byte[] Version { get; set; }
		public bool Deleted { get; set; }
		public virtual ICollection<EmployeeTimesheetValue> EmployeeTimesheetValues { get; set; }
	}
}
