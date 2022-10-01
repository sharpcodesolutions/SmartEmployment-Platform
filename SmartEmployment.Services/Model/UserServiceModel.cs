using Microsoft.AspNetCore.Mvc.Rendering;
using SmartEmployment.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Model
{
	public class UserServiceModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public bool IsEmployeeUser { get; set; }
		public Role Role { get; set; }
		public IEnumerable<SelectListItem> Roles { get; set; }
		
		public string CompanyCode { get; set; }
		public IEnumerable<SelectListItem> Companies { get; set; }
	}
}
