using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class Role : IdentityRole<int>, IEntityBase
	{
		public Role()
		{
			UserRoles = new HashSet<UserRole>();
		}
		// public int Id { get; set; }
		public string Name { get; set; }
		public byte[] Version { get; set; }
		public bool Deleted { get; set; }

		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
