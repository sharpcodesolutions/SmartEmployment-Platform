// See https://aka.ms/new-console-template for more information
using csharp2012forprogrammers.Models;

Console.WriteLine("Hello, World!");

CommissionEmployee employee = new CommissionEmployee("Sue", "Jones", "222-22-2222", 10000.00M, .06M);
Console.WriteLine(
	"Employee information obtained by properties and methods: \n"); 
Console.WriteLine("First name is {0}", employee.FirstName);
Console.WriteLine("Last name is {0}", employee.LastName);
Console.WriteLine("Social security number is {0}", employee.SocialSecurityNumber);
Console.WriteLine("Gross sales are {0:C}", employee.GrossSales);
Console.WriteLine("Commission rate is {0:F2}", employee.CommissionRate);
Console.WriteLine("Earnings are {0:C}", employee.Earnings());

employee.GrossSales = 5000.00M;
employee.CommissionRate = .1M;

Console.WriteLine("\n{0}:\n\n{1}",
	"Updated employee information obtained by ToString", employee);
Console.WriteLine("earnings: {0:C}", employee.Earnings()); 