using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
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
		public UserService(SmartEmploymentContext context)
		{
			_userRepository = new UserRepository(context);
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
    }
}
