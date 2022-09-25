using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;

namespace SmartEmployment.MVC.Controllers
{
	public class RolesController : Controller
	{

		private RoleRepository _roleRepository; 
		
		public RolesController(IEntityBaseRepository<Role> roleRepository)
		{
			_roleRepository = (RoleRepository)roleRepository;
		}

		// GET: RolesController
		[Authorize(Roles = "Global")]
		public ActionResult Index()
		{
			return View(_roleRepository.GetAll());
		}

		// GET: RolesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: RolesController/Create
		[Authorize(Roles = "Manager")]
		public ActionResult Create()
		{
			var role = new Role(); 
			return View(role);
		}

		// POST: RolesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			var role = new Role(); 
			try
			{
				role.Name = collection["Name"];
				_roleRepository.Add(role);
				_roleRepository.CreateRole(role.Name);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: RolesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: RolesController/Edit/5
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

		// GET: RolesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: RolesController/Delete/5
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
