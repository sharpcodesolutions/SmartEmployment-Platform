using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class Schedule : IEntityBase
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public TimeSpan? StartTime { get; set; }
		public TimeSpan? EndTime { get; set; }
		public decimal Hours { get; set; }
		public string Comments { get; set; }
		public bool Deleted { get; set; }
		public byte[] Version { get; set; }
		public int EmployeeId { get; set; }
		public int? TaskId { get; set; }

		public virtual Employee Employee { get; set; }
	}
}
