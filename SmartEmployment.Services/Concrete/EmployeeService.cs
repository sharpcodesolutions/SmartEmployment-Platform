using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
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
		public EmployeeService(SmartEmploymentContext context)
		{
			_employeeRepository = new EmployeeRepository(context);
		}
		public void AssignEmployeeToManager(string employeeCode, string managerCode)
        {
            throw new NotImplementedException();
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.Add(employee); 
        }

        public Employee CreateEmployeeForCompany(string companyCode, Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee CreateEmployeeForManager(string managerCode, Employee employee)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll().ToList(); 
        }

        public List<Employee> GetAllEmployeesForCompany(int companyId)
        {
            var employees = _employeeRepository.GetAll().ToList();
            return employees.Where(e => e.CompanyId == companyId).ToList();
        }

        public List<Employee> GetAllEmployeesForManager(string managerCode)
        {
            throw new NotImplementedException();
        }
    }
}
