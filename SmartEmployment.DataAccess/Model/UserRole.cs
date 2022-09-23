﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.DataAccess.Model
{
	public class UserRole : IEntityBase
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public int? RoleId { get; set; }
		public byte[] Version { get; set; }
		public bool? Deleted { get; set; }

		public virtual Role Role { get; set; }
		public virtual User User { get; set; }
	}
}