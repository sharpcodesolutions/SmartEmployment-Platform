using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using SmartEmployment.Services.Model;
using System.Net;
using System.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartEmployment.API.Controllers
{
	[Authorize(Roles = "Manager")]
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private IEmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		// GET: api/<EmployeesController>
		[HttpGet("{username}")]
		public IActionResult Get(string username)
		{
			try
			{
				var employees = _employeeService.GetAllEmployeesForUser(username);
				return Ok(employees);
			}
			catch(UnauthorizedAccessException e)
			{
				return StatusCode(StatusCodes.Status403Forbidden); 
			}
			catch(SecurityException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized);
			}
		}

		// GET: api/<EmployeesController>
		[HttpGet("schedules/{username}/{startDate}/{endDate}")]
		public IActionResult GetSchedules(string username, string startDate, string endDate)
		{
			try
			{
				var schedules = _employeeService.GetAllSchedulesForUser(username, startDate, endDate);
				return Ok(schedules);
			}
			catch (UnauthorizedAccessException e)
			{
				return StatusCode(StatusCodes.Status403Forbidden);
			}
			catch (SecurityException e)
			{
				return StatusCode(StatusCodes.Status401Unauthorized);
			}
		}

		/*
		// GET api/<EmployeesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}
		*/

		// POST api/<EmployeesController>
		[HttpPost("{username}")]
		public void Post([FromBody] EmployeeServiceModel employeeSM, string username)
		{
			_employeeService.CreateEmployee(employeeSM, username);
		}

		// POST api/<EmployeesController>
		[HttpPost("Schedules")]
		public void Post([FromBody] ScheduleServiceModel schedule)
		{
			_employeeService.AddSchedule(schedule);
		}

		// PUT api/<EmployeesController>/5
		[HttpPut("Schedules/{id}/{startTime}/{endTime}")]
		public void Put(int id, string startTime, string endTime, [FromBody] ScheduleServiceModel schedule)
		{
			_employeeService.UpdateSchedule(schedule, startTime, endTime);
		}

		// DELETE api/<EmployeesController>/5
		[HttpDelete("Schedules/{id}")]
		public void Delete(int id)
		{
			_employeeService.DeleteSchedule(id);
		}


		// PUT api/<EmployeesController>/5
		[HttpPut]
		public void Put([FromBody] EmployeeServiceModel employeeSM)
		{
			_employeeService.UpdateEmployee(employeeSM);
		}

		// DELETE api/<EmployeesController>/5
		[HttpDelete("{id}")]
		public void DeleteEmployee(int id)
		{
			_employeeService.DeleteEmployee(id);
		}		
	}
}
