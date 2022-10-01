using Microsoft.AspNetCore.Identity;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Concrete
{
    public class UserService : IUserService
    {
		private UserRepository _userRepository;
		private readonly UserManager<User> _userManager;
		private RoleRepository _roleRepository;
		public UserService(UserManager<User> userManager, SmartEmploymentContext context)
		{
			_userManager = userManager;
			_userRepository = new UserRepository(context);
			_roleRepository = new RoleRepository(context);
		}

        public User CreateNewUser(UserServiceModel userSV, int? roleId)
        {
			var user = new User();
			user.UserName = userSV.UserName;
			user.PasswordHash = userSV.Password;
			var result = _userManager.CreateAsync(user, user.PasswordHash).Result;
			if(roleId != null)
			{
				var role = _roleRepository.GetSingle(roleId.Value);
				var result1 = _userManager.AddToRoleAsync(user, role.Name); 
			}
			if (result.Succeeded)
			{
				return user;
			}
			else
			{
				throw new Exception("User cannot be created!"); 
			}
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList(); 
        }

		public User GetUserById(int userId)
        {
            return _userRepository.GetSingle(userId); 
        }

        public User GetUserByName(string userName)
        {
			var users = _userRepository.GetAll();
            return users.FirstOrDefault(u => u.UserName == userName);
		}

		public List<Role> GetAllRoles()
		{
			return _roleRepository.GetAll().ToList(); 
		}
	}
}
