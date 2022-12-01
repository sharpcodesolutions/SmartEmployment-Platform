using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using SmartEmployment.API.Controllers;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Test.SmartEmployment.API.Test
{
	public class EmployeesControllerTest
	{
		[Fact]
		public async Task Get_Employees_For_A_Manager()
		{
		}

		[Fact]
		public async Task Receive_Unauthorised_When_Username_Is_Not_A_Manager()
		{
		}
	}
}
