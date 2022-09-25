using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
		private CompanyRepository _companyRepository;
		private CompanyAddressRepository _companyAddressRepository;
		public CompanyService(SmartEmploymentContext context)
		{
			_companyRepository = new CompanyRepository(context);
			_companyAddressRepository = new CompanyAddressRepository(context);	
		}

		public List<Company> GetAllCompanies()
		{
			return _companyRepository.GetAll().ToList();
		}

		public void CreateCompany(Company company)
        {
			_companyRepository.Add(company);
        }

		public void CreateComapanyAddress(CompanyAddress companyAddress)
		{
			_companyAddressRepository.Add(companyAddress); 
		}

		public Company GetCompanyByCode(string companyCode)
		{
			return _companyRepository.GetAll().FirstOrDefault(c => c.CompanyCode == companyCode); 
		}

		public void CreateCompanyAddress(CompanyAddress companyAddress)
		{
			throw new NotImplementedException();
		}
	}
}
