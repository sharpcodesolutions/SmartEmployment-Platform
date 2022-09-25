using SmartEmployment.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        List<Employee> GetAllEmployeesForManager(string managerCode); 
        List<Employee> GetAllEmployeesForCompany(int companyId);
        public void CreateEmployee(Employee employee);
        public Employee CreateEmployeeForManager(string managerCode, Employee employee);
        public Employee CreateEmployeeForCompany(string companyCode, Employee employee);
        public void AssignEmployeeToManager(string employeeCode, string managerCode); 
    }
}
