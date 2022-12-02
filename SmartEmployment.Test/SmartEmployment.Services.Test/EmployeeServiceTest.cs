using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Services.Concrete;
using SmartEmployment.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static SmartEmployment.Test.SmartEmployment.API.Test.EmployeesControllerTest;

namespace SmartEmployment.Test.SmartEmployment.Services.Test
{
	public class EmployeeServiceTest
	{
		Mock<IEntityBaseRepository<Employee>> employeeRepositoryMock = new Mock<IEntityBaseRepository<Employee>>();
		Mock<IEntityBaseRepository<Person>> personRepositoryMock = new Mock<IEntityBaseRepository<Person>>();
		Mock<IEntityBaseRepository<Company>> companyRepositoryMock = new Mock<IEntityBaseRepository<Company>>();
		Mock<IEntityBaseRepository<User>> userRepositoryMock = new Mock<IEntityBaseRepository<User>>();
		Mock<IEntityBaseRepository<Relationship>> relationshipRepositoryMock = new Mock<IEntityBaseRepository<Relationship>>();
		Mock<IEntityBaseRepository<UserRole>> userRoleRepositoryMock = new Mock<IEntityBaseRepository<UserRole>>();
		Mock<IEntityBaseRepository<Role>> roleRepositoryMock = new Mock<IEntityBaseRepository<Role>>();
		Mock<IEntityBaseRepository<Schedule>> scheduleRepositoryMock = new Mock<IEntityBaseRepository<Schedule>>();
		
		public EmployeeServiceTest()
		{
			roleRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Role> {
				new Role
				{
					Id = 1,
					Name = "Manager"
				},
				new Role
				{
					Id = 2,
					Name = "Employee"
				}
			});

			employeeRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Employee>
			{
				new Employee
				{
					Id = 1,
					EmployeeCode = "90",
					CompanyId = 1,
					PersonId = 1
				},
				new Employee
				{
					Id=2,
					EmployeeCode = "01",
					CompanyId = 2,
					PersonId = 2
				},
				new Employee
				{
					Id = 3,
					EmployeeCode = "9840",
					CompanyId = 1,
					PersonId = 5
				},
				new Employee
				{
					Id=4,
					EmployeeCode = "061",
					CompanyId = 2,
					PersonId = 6
				}
			});

			userRoleRepositoryMock.Setup(ur => ur.GetAll()).Returns(new List<UserRole>
			{
				new UserRole
				{
					Id = 1,
					UserId = 1,
					RoleId = 1
				},
				new UserRole
				{
					Id = 2,
					UserId = 2,
					RoleId = 2
				}
			});

			userRepositoryMock.Setup(u => u.GetAll()).Returns(new List<User>
			{
				new User
				{
					Id = 1,
					UserName = "John",
					CompanyId = 1,
					PersonId = 3
				},
				new User
				{
					Id = 2,
					UserName = "Mat",
					CompanyId = 2,
					PersonId = 4
				}
			});

			companyRepositoryMock.Setup(c => c.GetAll()).Returns(new List<Company>
			{
				new Company
				{
					Id = 1,
					Name = "Datacom",
					CompanyCode = "DC"
				},
				new Company
				{
					Id = 2,
					Name = "Pixo",
					CompanyCode = "PIXO"
				}
			});

			personRepositoryMock.Setup(p => p.GetAll()).Returns(new List<Person>
			{
				new Person
				{
					Id = 1,
					FirstName = "Cindy",
					LastName = "Ooi"
				},
				new Person
				{
					Id = 2,
					FirstName = "Matthew",
					LastName = "O'Connor"
				},
				new Person
				{
					Id = 3,
					FirstName = "John",
					LastName = "Tanner"
				},
				new Person
				{
					Id = 4,
					FirstName = "Mat",
					LastName = "Smith"
				},
				new Person
				{
					Id = 5,
					FirstName = "Sam",
					LastName = "Tanner"
				},
				new Person
				{
					Id = 6,
					FirstName = "Jordan",
					LastName = "Smith"
				}
			});
		}

		[Fact]
		public void Get_Employees_For_A_Manager()
		{
			// Arrange
			EmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, personRepositoryMock.Object, companyRepositoryMock.Object,
				userRepositoryMock.Object, relationshipRepositoryMock.Object, userRoleRepositoryMock.Object, roleRepositoryMock.Object, scheduleRepositoryMock.Object); 
			
			// Act
			List<EmployeeServiceModel> employees = employeeService.GetAllEmployeesForUser("John");

			// Assert
			Assert.IsType<List<EmployeeServiceModel>>(employees);
		}

		[Fact]
		public void Returned_Employees_For_A_Manager_Are_In_The_Same_Company()
		{
			// Arrange
			EmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, personRepositoryMock.Object, companyRepositoryMock.Object,
				userRepositoryMock.Object, relationshipRepositoryMock.Object, userRoleRepositoryMock.Object, roleRepositoryMock.Object, scheduleRepositoryMock.Object);

			// Act
			List<EmployeeServiceModel> employees = employeeService.GetAllEmployeesForUser("John");

			int count = employees.Select(e => e.CompanyCode)
				.Distinct().Count(); 

			// Assert
			Assert.Equal(count.ToString(), "1");
		}

		[Fact]
		public void Receive_UnauthorisedAccessException_When_Username_Is_Not_A_Manager()
		{
			// Arrange
			EmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, personRepositoryMock.Object, companyRepositoryMock.Object,
				userRepositoryMock.Object, relationshipRepositoryMock.Object, userRoleRepositoryMock.Object, roleRepositoryMock.Object, scheduleRepositoryMock.Object);

			// Act 
			// Assert
			Assert.Throws<UnauthorizedAccessException>(() => employeeService.GetAllEmployeesForUser("Mat"));
		}

		[Fact]
		public void Receive_SecurityException_When_A_User_Does_Not_Exist()
		{
			// Arrange
			EmployeeService employeeService = new EmployeeService(employeeRepositoryMock.Object, personRepositoryMock.Object, companyRepositoryMock.Object,
				userRepositoryMock.Object, relationshipRepositoryMock.Object, userRoleRepositoryMock.Object, roleRepositoryMock.Object, scheduleRepositoryMock.Object);

			// Act 
			// Assert
			Assert.Throws<SecurityException>(() => employeeService.GetAllEmployeesForUser("David"));
		}
	}
}
