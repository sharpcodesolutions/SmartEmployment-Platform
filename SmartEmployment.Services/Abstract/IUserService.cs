using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Abstract
{
	public interface IUserService
	{
		public List<User> GetAllUsers(); 
		public User GetUserById(int userId);
		public User GetUserByName(string userName);
		public User CreateNewUser(UserServiceModel user, int? roleId); 
		public List<Role> GetAllRoles();
	}
}
