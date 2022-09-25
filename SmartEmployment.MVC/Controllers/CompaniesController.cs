using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;

namespace SmartEmployment.MVC.Controllers
{
    [Authorize(Roles = "Global")]
    public class CompaniesController : Controller
    {
		private CompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = (CompanyService)companyService;
        }

		// GET: CompaniesController
		public ActionResult Index()
        {
            return View(_companyService.GetAllCompanies());
        }

        // GET: CompaniesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var company = new Company();
            try
            {
                company.Name = collection["Name"];
                company.CompanyCode = collection["CompanyCode"];
                company.StartDate = DateTime.Now;
                _companyService.CreateCompany(company);
                var newCompany = _companyService.GetCompanyByCode(company.CompanyCode);
                var address = new CompanyAddress();
                address.PostalCode = collection["PostalCode"];
                address.CompanyId = newCompany.Id;
                address.Building = "2";
                address.City = "Sydney";
                address.Street = "Memorial Avenue";
                address.House = "47";
                address.Unit = "4";
                address.XCoordinate = 1;
                address.YCoordinate = 2;
                _companyService.CreateComapanyAddress(address); 
				return RedirectToAction(nameof(Index));
			}
            catch
            {
                return View();
            }
        }

        // GET: CompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompaniesController/Edit/5
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

        // GET: CompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompaniesController/Delete/5
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
