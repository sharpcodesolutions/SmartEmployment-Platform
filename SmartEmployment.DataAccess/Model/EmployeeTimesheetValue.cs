using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class EmployeeTimesheetValue
	{
		public EmployeeTimesheetValue()
		{
		}
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public int TimesheetId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public decimal Length { get; set; }
		public byte[] Version { get; set; }
		public bool Deleted { get; set; }

		public virtual Employee Employee { get; set; }
		public virtual Timesheet Timesheet { get; set; }
	}
}
