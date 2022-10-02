using SmartEmployment.DataAccess.Model;
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
    public class EmployeeService : IEmployeeService
    {
		private EmployeeRepository _employeeRepository;
        private PersonRepository _personRepository;
        private CompanyRepository _companyRepository;
        private UserRepository _userRepository;
		public EmployeeService(SmartEmploymentContext context)
		{
			_employeeRepository = new EmployeeRepository(context);
            _personRepository = new PersonRepository(context);
            _companyRepository = new CompanyRepository(context);
            _userRepository = new UserRepository(context);
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
			foreach(var employeeSM in employees)
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
		}

		public List<EmployeeServiceModel> GetAllEmployeesForUser(int userId)
		{
            var user = _userRepository.GetSingle(userId); 
            if (user == null)
            {

            }
			List<EmployeeServiceModel> employeeSMs = new List<EmployeeServiceModel>();
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
			return employeeSMs.ToList();
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
