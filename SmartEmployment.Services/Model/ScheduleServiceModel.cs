using SmartEmployment.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Model
{
	public class ScheduleServiceModel
	{
		public int Id { get; set; }
		public int DayIndex { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public decimal? Hours { get; set; }
		public string? Comments { get; set; }
		public int EmployeeId { get; set; }
		public int? TaskId { get; set; }
	}
}
