using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Repository.Concrete
{
	public class CompanyRepository : EntityBaseRepository<Company>
	{
		public CompanyRepository() : base() { }
	}
}
