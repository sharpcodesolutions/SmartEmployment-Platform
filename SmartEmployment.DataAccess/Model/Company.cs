using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class Company : IEntityBase
	{
		public Company()
		{
			Employees = new HashSet<Employee>();
			Users = new HashSet<User>();
			CompanyAddresses = new HashSet<CompanyAddress>();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public byte[] Version { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? FinishedDate { get; set; }
		public bool Deleted { get; set; }
		public string CommpanyCode { get; set; }
		public int? CompanyHead { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
	}
}
