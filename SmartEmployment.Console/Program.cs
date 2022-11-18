using Microsoft.EntityFrameworkCore;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Concrete;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

/*
var connectionstring = "Server=DESKTOP-C76N1G2;Database=SmartEmployment;Trusted_Connection=True;";

var optionsBuilder = new DbContextOptionsBuilder<SharpEmploymentContext>();
optionsBuilder.UseSqlServer(connectionstring);
*/

SmartEmploymentContext dbContext = new SmartEmploymentContext();

var company = new Company();
var companyRepository = new CompanyRepository();

var person = new Person();
var personRepository = new PersonRepository();

var relationship = new Relationship();
relationship.EmployeeCode = "JKJ";
relationship.ManagerCode = "SDD"; 
relationship.StartDate = DateTime.Now;
var relationshipRepository = new RelationshipRepository();
relationshipRepository.Add(relationship); 

var rr = relationshipRepository.GetAll(); 


Console.WriteLine("Process completed!" + rr.ToString());

var role = new Role(); 
// var roleRepository = new RoleRepository(dbContext);
// var allRoles = roleRepository.GetAll();
// Console.WriteLine(allRoles.Count());

/*
Console.Write("Enter first name:  ");
person.FirstName = Console.ReadLine();
Console.Write("Now company name: ");
company.Name = Console.ReadLine();
Console.Write("Enter last name: ");
person.LastName = Console.ReadLine();
Console.Write("Enter company code: ");
company.CommpanyCode = Console.ReadLine(); 
Console.Write("Enter email address: ");
person.Email = Console.ReadLine(); 
company.StartDate = DateTime.Now;

person.BirthDate = new DateTime(2001, 1, 1);
person.MiddleName = "Someone";
person.PreferredName = ""; 

var companies = companyRepository.GetAll();
var people = personRepository.GetAll(); 

if(companies.Any(c => c.CommpanyCode == company.CommpanyCode))
{
	Console.WriteLine("Company already exists!"); 
}
else
{
	companyRepository.Add(company);
}

personRepository.Add(person);

Console.WriteLine(company.Name);

*/