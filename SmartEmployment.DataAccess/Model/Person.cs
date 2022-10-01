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
	public class Person : IEntityBase
	{
		public Person()
		{
			Employees = new HashSet<Employee>();
			Users = new HashSet<User>();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public byte[] Version { get; set; }
		public string? PreferredName { get; set; }
		public int? Gender { get; set; }
		public int? Title { get; set; }
		[DataType(DataType.Date)]
		public DateTime BirthDate { get; set; }
		public string Email { get; set; }
		public bool Deleted { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}
