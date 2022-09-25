using SmartEmployment.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Services.Abstract
{
    public interface ICompanyService
    {
        public List<Company> GetAllCompanies();
        public Company GetCompanyByCode(string companyCode); 
		public void CreateCompany(Company company);
        public void CreateCompanyAddress(CompanyAddress companyAddress); 
    }
}
