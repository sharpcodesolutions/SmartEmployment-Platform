﻿using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEmployment.Repository.Concrete
{
	public class PersonRepository : EntityBaseRepository<Person>
	{
		public PersonRepository(SharpEmploymentContext context) : base(context) { }
	}
}
