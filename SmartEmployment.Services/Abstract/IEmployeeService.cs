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
		List<EmployeeServiceModel> GetAllEmployeesForUser(string username);
        void DeleteSchedule(int Id);
        void UpdateSchedule(ScheduleServiceModel schedule, string startTime, string endTime);
        void AddSchedule(ScheduleServiceModel schedule);
        IEnumerable<Schedule> GetAllSchedulesForUser(string username, string startDate, string endDate);
		List<EmployeeServiceModel> GetAllEmployeesForManager(string managerCode); 
        List<EmployeeServiceModel> GetAllEmployeesForCompany(int companyId);
        public void CreateEmployee(EmployeeServiceModel employee, string username);
		public void CreateEmployees(List<EmployeeServiceModel> employee);
		public EmployeeServiceModel CreateEmployeeForManager(string managerCode, EmployeeServiceModel employee);
        public EmployeeServiceModel CreateEmployeeForCompany(string companyCode, EmployeeServiceModel employee);
		void DeleteEmployee(int Id);
		void UpdateEmployee(EmployeeServiceModel employeeSM);
		public void AssignEmployeeToManager(string employeeCode, string managerCode); 
    }
}
