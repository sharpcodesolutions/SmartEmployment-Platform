using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartEmployment.Authentication.API.Models;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Services.Abstract;
using SmartEmployment.Services.Concrete;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

// Add services to the container.
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<SmartEmploymentContext>();
builder.Services.AddScoped<IUserService, UserService>();

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
	}).AddRoleManager<RoleManager<Role>>()
	.AddRoles<Role>()
	.AddEntityFrameworkStores<SmartEmploymentContext>()
	.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, Role>>()
		.AddDefaultTokenProviders();

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
