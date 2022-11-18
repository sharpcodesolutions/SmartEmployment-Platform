using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		private CompanyRepository _companyRepository;
		private PersonRepository _personRepository;
		private UserRoleRepository _userRoleRepository;
		public UserService(UserManager<User> userManager)
		{
			_userManager = userManager;
			_userRepository = new UserRepository();
			_roleRepository = new RoleRepository();
			_companyRepository = new CompanyRepository();
			_personRepository = new PersonRepository();
			_userRoleRepository = new UserRoleRepository();
		}

        public User CreateNewUser(UserServiceModel userSV, int? roleId)
        {
			// Create Person first
			var person = new Person();
			person.FirstName = userSV.Firstname;
			person.LastName = userSV.Lastname;
			person.Email = userSV.Email;
			person.BirthDate = userSV.Birthdate;
			var newPerson = _personRepository.Add(person);

			var user = new User();
			user.UserName = userSV.UserName;
			user.PasswordHash = userSV.Password;
			user.StartDate = userSV.StartDate;
			user.FinishedDate = userSV.EndDate;
			if (userSV.CompanyCode != null)
			{
				user.CompanyId = _companyRepository.GetAll().FirstOrDefault(c => c.CompanyCode == userSV.CompanyCode).Id;
			}
			user.PersonId = newPerson.Id; 
			
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

        public List<UserServiceModel> GetAllUsers()
        {
			List<UserServiceModel> allUserServiceModel = new List<UserServiceModel>();
			var allUsers = _userRepository.GetAll().ToList(); 
			foreach(var user in allUsers)
			{
				allUserServiceModel.Add(MapUserToUserServiceModel(user));
			}
			return allUserServiceModel;
        }

		public User GetUserById(int userId)
        {
            return _userRepository.GetSingle(userId); 
        }

        public UserServiceModel GetUserByName(string userName)
        {
			var user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == userName);
			if (user != null)
			{
				return MapUserToUserServiceModel(user);
			}
			else
			{
				return null; 
			}
		}

		public List<Role> GetAllRoles()
		{
			return _roleRepository.GetAll().ToList(); 
		}

		public List<string> GetRolesForUser(string username)
		{
			var user = GetUserByName(username);
			var userRoles = _userRoleRepository.GetAll().Where(ur => ur.UserId == user.Id);
			var roles = _roleRepository.GetAll().Where(r => userRoles.Any(ur => ur.RoleId == r.Id)).Select(r => r.Name).ToList();
			return roles; 
		}

		private UserServiceModel MapUserToUserServiceModel(User user)
		{
			var userServiceModel = new UserServiceModel();
			var userroles = _userRoleRepository.GetAll().Where(ur => ur.UserId == user.Id);

			userServiceModel.Id = user.Id;
			userServiceModel.UserName = user.UserName;
			userServiceModel.Password = user.PasswordHash; 
			userServiceModel.Roles = _roleRepository.GetAll()
				.Where(r => userroles.Any(ur => ur.RoleId == r.Id))
				.Select(r => new SelectListItem() { Text = r.Name, Value = r.Name});

			if (user.PersonId != null)
			{
				var person = _personRepository.GetSingle(user.PersonId.Value);
				userServiceModel.Firstname = person.FirstName;
				userServiceModel.Lastname = person.LastName;
				userServiceModel.Email = person.Email;
				userServiceModel.Birthdate = person.BirthDate;
			}

			return userServiceModel;
		}
	}
}
