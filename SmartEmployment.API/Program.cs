using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartEmployment.API.Models;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors(options =>
	 options.WithOrigins("http://localhost:4200")
			.AllowAnyHeader()
			.AllowAnyMethod());

app.UseAuthentication(); 
app.UseAuthorization();

app.Run();
