using SmartEmployment.DataAccess.Model;
using SmartEmployment.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Abstract
{
    public interface IEmployeeService
    {
        List<EmployeeServiceModel> GetAllEmployees();
		List<EmployeeServiceModel> GetAllEmployeesForUser(int userId);
		List<EmployeeServiceModel> GetAllEmployeesForManager(string managerCode); 
        List<EmployeeServiceModel> GetAllEmployeesForCompany(int companyId);
        public void CreateEmployee(EmployeeServiceModel employee, User user);
		public void CreateEmployees(List<EmployeeServiceModel> employee);
		public EmployeeServiceModel CreateEmployeeForManager(string managerCode, EmployeeServiceModel employee);
        public EmployeeServiceModel CreateEmployeeForCompany(string companyCode, EmployeeServiceModel employee);
        public void AssignEmployeeToManager(string employeeCode, string managerCode); 
    }
}
