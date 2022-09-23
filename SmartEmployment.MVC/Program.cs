using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using Microsoft.AspNetCore.Identity.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SmartEmploymentContext>();

builder.Services.AddIdentity<User, Role>(
	options =>
	{
		options.SignIn.RequireConfirmedAccount = false;
		options.Password.RequireDigit = true;
		options.Password.RequireLowercase = true;
		options.Password.RequireNonAlphanumeric = true;
		options.Password.RequireUppercase = true;
		options.Password.RequiredLength = 6;
		options.Password.RequiredUniqueChars = 1;
	}).AddEntityFrameworkStores<SmartEmploymentContext>()
		.AddDefaultTokenProviders();

// builder.Services.AddScoped<IEntityBaseRepository<Role>, RoleRepository>();

builder.Services.ConfigureApplicationCookie(options =>
{
	// Cookie settings
	options.Cookie.HttpOnly = true;
	//options.Cookie.Expiration 

	options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
	options.LoginPath = "/Identity/Account/Login";
	options.LogoutPath = "/Identity/Account/Logout";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.SlidingExpiration = true;
	//options.ReturnUrlParameter=""
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Login}/{id?}");
	endpoints.MapRazorPages();
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
