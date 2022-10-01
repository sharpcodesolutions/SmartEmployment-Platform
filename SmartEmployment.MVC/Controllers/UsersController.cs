using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using SmartEmployment.Services.Model;

namespace SmartEmployment.MVC.Controllers
{
    public class UsersController : Controller
    {
        private UserService _userService;
        private CompanyService _companyService;

        public UsersController(IUserService userService, ICompanyService companyService)
        {
            _userService = (UserService)userService;
            _companyService = (CompanyService)companyService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            return View(_userService.GetAllUsers());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            UserServiceModel user = new UserServiceModel();
			List<SelectListItem> roles = _userService.GetAllRoles()
						.Select(r =>
						new SelectListItem
						{
							Value = r.Id.ToString(),
							Text = r.Name
						}).ToList();
			List<SelectListItem> companies = _companyService.GetAllCompanies()
						.Select(c =>
						new SelectListItem
						{
							Value = c.CompanyCode,
							Text = c.Name
						}).ToList();
            user.Roles = roles;
            user.Companies = companies;
            return View(user);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            UserServiceModel userSV = new UserServiceModel();
            userSV.UserName = collection["UserName"];
            userSV.Password = collection["Password"];
            var comapny = collection["CompanyCode"];
            var role = int.Parse(collection["Role"]);
            try
            {
                _userService.CreateNewUser(userSV, role); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
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

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
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
