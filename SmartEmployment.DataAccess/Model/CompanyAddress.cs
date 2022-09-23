using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class CompanyAddress : IEntityBase
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Street { get; set; }
		public string House { get; set; }
		public string Building { get; set; }
		public string Unit { get; set; }
		public decimal XCoordinate { get; set; }
		public decimal YCoordinate { get; set; }
		public bool? Deleted { get; set; }
		public byte[] Version { get; set; }
		public virtual Company Company { get; set; }
	}
}
