using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
    public class Relationship : IEntityBase
	{
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string ManagerCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishedDate { get; set; }
		public byte[] Version { get; set; }
		public bool Deleted { get; set; }
	}
}
