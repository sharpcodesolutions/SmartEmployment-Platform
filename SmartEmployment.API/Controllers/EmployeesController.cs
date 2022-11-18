using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using SmartEmployment.Services.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartEmployment.API.Controllers
{
	[Authorize(Roles = "Manager")]
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private EmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = (EmployeeService)employeeService;
		}

		// GET: api/<EmployeesController>
		[HttpGet]
		public IEnumerable<EmployeeServiceModel> Get()
		{
			return _employeeService.GetAllEmployees();
		}

		// GET api/<EmployeesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<EmployeesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<EmployeesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EmployeesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
