using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Repository.Concrete
{
    public class RoleRepository : EntityBaseRepository<Role>
	{
		public RoleRepository() : base() { }

		public async Task CreateRole(string roleName)
		{
			var roleStore = new RoleStore<IdentityRole>(new SmartEmploymentContext());
			//if (roleStore.FindByNameAsync(roleName) == null)
			{
				var role = new Role();
				role.Name = roleName;
				await roleStore.CreateAsync(new IdentityRole(roleName));
			}
		}
	}
}
