using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartEmployment.API.Models;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Repository.Abstract;
using SmartEmployment.Repository.Concrete;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IEntityBaseRepository<Employee>, EntityBaseRepository<Employee>>();
builder.Services.AddScoped<IEntityBaseRepository<Person>, EntityBaseRepository<Person>>();
builder.Services.AddScoped<IEntityBaseRepository<Company>, EntityBaseRepository<Company>>();
builder.Services.AddScoped<IEntityBaseRepository<User>, EntityBaseRepository<User>>();
builder.Services.AddScoped<IEntityBaseRepository<Relationship>, EntityBaseRepository<Relationship>>();
builder.Services.AddScoped<IEntityBaseRepository<UserRole>, EntityBaseRepository<UserRole>>();
builder.Services.AddScoped<IEntityBaseRepository<Role>, EntityBaseRepository<Role>>();
builder.Services.AddScoped<IEntityBaseRepository<Schedule>, EntityBaseRepository<Schedule>>();

builder.Services.AddScoped<EntityBaseRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<EntityBaseRepository<Person>, PersonRepository>();
builder.Services.AddScoped<EntityBaseRepository<Company>, CompanyRepository>();
builder.Services.AddScoped<EntityBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<EntityBaseRepository<Relationship>, RelationshipRepository>();
builder.Services.AddScoped<EntityBaseRepository<UserRole>, UserRoleRepository>();
builder.Services.AddScoped<EntityBaseRepository<Role>, RoleRepository>();
builder.Services.AddScoped<EntityBaseRepository<Schedule>, ScheduleRepository>();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = jwtSettings["validIssuer"],
		ValidAudience = jwtSettings["validAudience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
			.GetBytes(jwtSettings.GetSection("securityKey").Value))
	};
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors(options =>
	 options.WithOrigins("http://localhost:4200")
			.AllowAnyHeader()
			.AllowCredentials()
			.AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.Run();

public partial class Program { }