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
		private CompanyRepository _companyRepository;
		private PersonRepository _personRepository;
		public UserService(UserManager<User> userManager, SmartEmploymentContext context)
		{
			_userManager = userManager;
			_userRepository = new UserRepository(context);
			_roleRepository = new RoleRepository(context);
			_companyRepository = new CompanyRepository(context);
			_personRepository = new PersonRepository(context);
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
