using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartEmployment.Authentication.API.Models;
using SmartEmployment.DataAccess.Model;
using SmartEmployment.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SmartEmployment.Authentication.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly JwtHandler _jwtHandler;
		private readonly IUserService _userService;
		public AccountsController(UserManager<User> userManager, IMapper mapper, JwtHandler jwtHandler, IUserService userService)
		{
			_userManager = userManager;
			_mapper = mapper;
			_jwtHandler = jwtHandler;
			_userService = userService;
		}
		[HttpPost("Registration")]
		public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
		{
			if (userForRegistration == null || !ModelState.IsValid)
				return BadRequest();

			var user = _mapper.Map<User>(userForRegistration);
			var result = await _userManager.CreateAsync(user, userForRegistration.Password);
			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description);

				return BadRequest(new RegistrationResponseDto { Errors = errors });
			}

			return StatusCode(201);
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
		{
			var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
			if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
				return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
			var signingCredentials = _jwtHandler.GetSigningCredentials();
			var claims = new List<Claim>();
			claims.Add(new Claim("username", user.UserName));

			var roles = _userService.GetRolesForUser(user.UserName); 
			foreach(var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role)); 
			}
			// var claims = _jwtHandler.GetClaims(user);
			var userRoles = _userService.GetRolesForUser(user.UserName); 
			var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
			var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
		}
	}
}
