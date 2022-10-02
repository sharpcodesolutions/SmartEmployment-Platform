using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using SmartEmployment.Services.Model;
using System.ComponentModel;
using System.Data;
using System.Security.Claims;

namespace SmartEmployment.MVC.Controllers
{
    [Authorize(Roles = "Global, Manager, Admin")]
    public class EmployeesController : Controller
    {
		private EmployeeService _employeeService;
		private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
		private IConfiguration Configuration;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = (EmployeeService)employeeService;
		}

		// GET: EmployeesController
		public ActionResult Index()
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			return View(_employeeService.GetAllEmployees());
        }

		[HttpPost]
		public IActionResult Index(IFormFile file, [FromServices] Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
		{
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush(); 
            }
            var employees = this.GetEmployeeList(file.FileName);
            _employeeService.CreateEmployees(employees); 
            return View(_employeeService.GetAllEmployees());
		}

        private List<EmployeeServiceModel> GetEmployeeList(string fName)
        {
            List<EmployeeServiceModel> employees = new List<EmployeeServiceModel>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        employees.Add(new EmployeeServiceModel()
                        {
                            EmployeeCode = reader.GetValue(0).ToString(),
                            CompanyCode = reader.GetValue(1).ToString(),
                            Firstname = reader.GetValue(2).ToString(),
                            Lastname = reader.GetValue(3).ToString(),
                            EmployeeEmail = reader.GetValue(4).ToString(),
                            Birthdate = Convert.ToDateTime(reader.GetValue(5).ToString()),
                            StartDate = Convert.ToDateTime(reader.GetValue(6).ToString()),
                            TerminationDate = Convert.ToDateTime(reader.GetValue(7).ToString())
                        });
                    }
                }
                return employees;
            }
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
