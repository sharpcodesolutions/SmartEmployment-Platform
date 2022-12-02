using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
		private IEntityBaseRepository<Employee> _employeeRepository;
        private IEntityBaseRepository<Person> _personRepository;
        private IEntityBaseRepository<Company> _companyRepository;
        private IEntityBaseRepository<User> _userRepository;
        private IEntityBaseRepository<Relationship> _relationshipRepository; 
        private IEntityBaseRepository<UserRole> _userRoleRepository;
        private IEntityBaseRepository<Role> _roleRepository;
        private IEntityBaseRepository<Schedule> _scheduleRepository;
		public EmployeeService(IEntityBaseRepository<Employee> employeeRepository, IEntityBaseRepository<Person> personRepository,
            IEntityBaseRepository<Company> companyRepository, IEntityBaseRepository<User> userRepository, 
            IEntityBaseRepository<Relationship> relationshipRepository, IEntityBaseRepository<UserRole> userRoleRepository, 
            IEntityBaseRepository<Role> roleRepository, IEntityBaseRepository<Schedule> scheduleRepository)
		{
			_employeeRepository = employeeRepository;
            _personRepository = personRepository;
            _companyRepository = companyRepository;
            _userRepository = userRepository;
            _relationshipRepository = relationshipRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _scheduleRepository = scheduleRepository;
		}
		public void AssignEmployeeToManager(string employeeCode, string managerCode)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(EmployeeServiceModel employee, User user)
        {
			throw new NotImplementedException();
		}

		public void CreateEmployees(List<EmployeeServiceModel> employees)
		{
			throw new NotImplementedException();
            /*
			foreach (var employeeSM in employees)
            {
                Person person = new Person
                {
                    FirstName = employeeSM.Firstname, 
                    LastName = employeeSM.Lastname, 
                    BirthDate = employeeSM.Birthdate, 
                    Email = employeeSM.EmployeeEmail
                };
                var newPerson = _personRepository.Add(person);

                Employee employee = new Employee();
                // {
                employee.EmployeeCode = employeeSM.EmployeeCode;
                employee.StartDate = employeeSM.StartDate;
                employee.TerminationDate = employeeSM.TerminationDate;
                // List<Person> people = _personRepository.GetAll().ToList(); 
                // var newPerson = people.FirstOrDefault(p => p.Email == employeeSM.EmployeeEmail);
                employee.PersonId = newPerson.Id;
			    // };
                employee.CompanyId = _companyRepository.GetAll().FirstOrDefault(c => c.CompanyCode == employeeSM.CompanyCode).Id;
                _employeeRepository.Add(employee);
            }
            */
		}

		public EmployeeServiceModel CreateEmployeeForCompany(string companyCode, EmployeeServiceModel employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeServiceModel CreateEmployeeForManager(string managerCode, EmployeeServiceModel employee)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeServiceModel> GetAllEmployees()
        {
			throw new NotImplementedException();
            /*
			List<EmployeeServiceModel> employeeSMs = new List<EmployeeServiceModel>(); 
            var employees = _employeeRepository.GetAll();
            foreach(var employee in employees)
            {
				EmployeeServiceModel employeeSM = new EmployeeServiceModel();
                employeeSM.Id = employee.Id;
                employeeSM.EmployeeCode = employee.EmployeeCode; 
                var companies = _companyRepository.GetAll();
                employeeSM.CompanyCode = companies.FirstOrDefault(c => c.Id == employee.CompanyId).CompanyCode;
                var people = _personRepository.GetAll();
                var person = people.FirstOrDefault(p => p.Id == employee.PersonId);
				employeeSM.Firstname = person.FirstName;
				employeeSM.Lastname = person.LastName;
                employeeSM.Birthdate = person.BirthDate;
                employeeSM.StartDate = employee.StartDate;
                employeeSM.TerminationDate = employee.TerminationDate; 
                employeeSMs.Add(employeeSM);
			}
            return employeeSMs.ToList();
            */
		}

		public List<EmployeeServiceModel> GetAllEmployeesForUser(int userId)
		{
			throw new NotImplementedException();
            /*
			var user = _userRepository.GetSingle(userId);
			List<EmployeeServiceModel> employeeSMs = new List<EmployeeServiceModel>();
			if (user == null || user.EmployeeId == null)
            {                
                var employees = _employeeRepository.GetAll();
                foreach (var employee in employees)
                {
                    EmployeeServiceModel employeeSM = new EmployeeServiceModel();
                    employeeSM.Id = employee.Id;
                    employeeSM.EmployeeCode = employee.EmployeeCode;
                    var companies = _companyRepository.GetAll();
                    employeeSM.CompanyCode = companies.FirstOrDefault(c => c.Id == employee.CompanyId).CompanyCode;
                    var people = _personRepository.GetAll();
                    var person = people.FirstOrDefault(p => p.Id == employee.PersonId);
                    employeeSM.Firstname = person.FirstName;
                    employeeSM.Lastname = person.LastName;
                    employeeSM.Birthdate = person.BirthDate;
                    employeeSM.StartDate = employee.StartDate;
                    employeeSM.TerminationDate = employee.TerminationDate;
                    employeeSMs.Add(employeeSM);
                }
            }
            else
            {
                var employees1 = _employeeRepository.GetAll();
                var managerCode = _employeeRepository.GetSingle(user.EmployeeId.Value).EmployeeCode;
                var relationships = _relationshipRepository.GetAll().ToList();
                var jjj = relationships.Where(r => r.ManagerCode == managerCode).ToList();
                var employeeCodes = jjj.Where(r => r.ManagerCode == managerCode).ToList(); 
                var jj = employeeCodes.Select(r => r.EmployeeCode).ToList();
                var employees = employees1.Where(e => jj.Contains(e.EmployeeCode)).ToList();
                foreach (var employee in employees)
                {
                    EmployeeServiceModel employeeSM = new EmployeeServiceModel();
                    employeeSM.Id = employee.Id;
                    employeeSM.EmployeeCode = employee.EmployeeCode;
                    var companies = _companyRepository.GetAll();
                    employeeSM.CompanyCode = companies.FirstOrDefault(c => c.Id == employee.CompanyId).CompanyCode;
                    var people = _personRepository.GetAll();
                    var person = people.FirstOrDefault(p => p.Id == employee.PersonId);
                    employeeSM.Firstname = person.FirstName;
                    employeeSM.Lastname = person.LastName;
                    employeeSM.Birthdate = person.BirthDate;
                    employeeSM.StartDate = employee.StartDate;
                    employeeSM.TerminationDate = employee.TerminationDate;
                    employeeSMs.Add(employeeSM);
                }
            }
			return employeeSMs.ToList();
            */
		}

		public List<EmployeeServiceModel> GetAllEmployeesForUser(string username)
		{
            var user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                throw new SecurityException();
            }
            var userRoles = _userRoleRepository.GetAll().Where(ur => ur.UserId == user.Id);
            var roles = _roleRepository.GetAll();
            var currentRoles = new List<Role>(); 
         
            if (userRoles != null && userRoles.Count() > 0)
            {
                currentRoles = roles.Where(r => userRoles.Any(ur => ur.RoleId == r.Id)).ToList();
            }
            else
            {
                throw new UnauthorizedAccessException(); 
            }

            if (currentRoles != null && currentRoles.Count() > 0 && currentRoles.Any(r => r.Name == "Manager"))
            {

                List<EmployeeServiceModel> employeeSMs = new List<EmployeeServiceModel>();
                if (user == null || user.EmployeeId == null)
                {
                    var employees = _employeeRepository.GetAll().Where(e => e.CompanyId == user.CompanyId); 
                    foreach (var employee in employees)
                    {
                        EmployeeServiceModel employeeSM = new EmployeeServiceModel();
                        employeeSM.Id = employee.Id;
                        employeeSM.EmployeeCode = employee.EmployeeCode;
                        var companies = _companyRepository.GetAll();
                        employeeSM.CompanyCode = companies.FirstOrDefault(c => c.Id == employee.CompanyId).CompanyCode;
                        var people = _personRepository.GetAll();
                        var person = people.FirstOrDefault(p => p.Id == employee.PersonId);
                        employeeSM.Firstname = person.FirstName;
                        employeeSM.Lastname = person.LastName;
                        employeeSM.Birthdate = person.BirthDate;
                        employeeSM.StartDate = employee.StartDate;
                        employeeSM.TerminationDate = employee.TerminationDate;
                        employeeSMs.Add(employeeSM);
                    }
                }
                else
                {
                    var employees1 = _employeeRepository.GetAll();
                    var managerCode = _employeeRepository.GetSingle(user.EmployeeId.Value).EmployeeCode;
                    var relationships = _relationshipRepository.GetAll();
                    var jjj = relationships.Where(r => r.ManagerCode == managerCode).ToList();
                    var employeeCodes = jjj.Where(r => r.ManagerCode == managerCode).ToList();
                    var jj = employeeCodes.Select(r => r.EmployeeCode).ToList();
                    var employees = employees1.Where(e => jj.Contains(e.EmployeeCode)).ToList();
                    foreach (var employee in employees)
                    {
                        EmployeeServiceModel employeeSM = new EmployeeServiceModel();
                        employeeSM.Id = employee.Id;
                        employeeSM.EmployeeCode = employee.EmployeeCode;
                        var companies = _companyRepository.GetAll();
                        employeeSM.CompanyCode = companies.FirstOrDefault(c => c.Id == employee.CompanyId).CompanyCode;
                        var people = _personRepository.GetAll();
                        var person = people.FirstOrDefault(p => p.Id == employee.PersonId);
                        employeeSM.Firstname = person.FirstName;
                        employeeSM.Lastname = person.LastName;
                        employeeSM.Birthdate = person.BirthDate;
                        employeeSM.StartDate = employee.StartDate;
                        employeeSM.TerminationDate = employee.TerminationDate;
                        employeeSMs.Add(employeeSM);
                    }
                }
                return employeeSMs.ToList();
            }
            else
            {
                throw new UnauthorizedAccessException(); 
            }
		}

		public IEnumerable<Schedule> GetAllSchedulesForUser(string username)
		{
			var user = _userRepository.GetAll().FirstOrDefault(u => u.UserName == username);
			if (user == null)
			{
				throw new SecurityException();
			}
			var userRoles = _userRoleRepository.GetAll().Where(ur => ur.UserId == user.Id);
			var roles = _roleRepository.GetAll();
			var currentRoles = new List<Role>();

			if (userRoles != null && userRoles.Count() > 0)
			{
				currentRoles = roles.Where(r => userRoles.Any(ur => ur.RoleId == r.Id)).ToList();
			}
			else
			{
				throw new UnauthorizedAccessException();
			}

			if (currentRoles != null && currentRoles.Count() > 0 && currentRoles.Any(r => r.Name == "Manager"))
			{
                IEnumerable<Schedule> allSchedules = _scheduleRepository.GetAll();
				List<Employee> employees = _employeeRepository.GetAll().Where(e => e.CompanyId == user.CompanyId).ToList();
				IEnumerable<Schedule> schedules = allSchedules.Where(s => employees.Any(e => e.Id == s.EmployeeId));

                return schedules; 
			}
			else
			{
				throw new UnauthorizedAccessException();
			}
		}

        void DeleteSchedule(int Id)
        {
            var schedule = _scheduleRepository.GetSingle(Id);
            _scheduleRepository.Delete(schedule);
        }

		void UpdateSchedule(Schedule schedule)
        { 
            _scheduleRepository.Update(schedule);
        }

		public List<EmployeeServiceModel> GetAllEmployeesForCompany(int companyId)
        {
			throw new NotImplementedException();
		}

        public List<EmployeeServiceModel> GetAllEmployeesForManager(string managerCode)
        {
            throw new NotImplementedException();
        }
    }
}
