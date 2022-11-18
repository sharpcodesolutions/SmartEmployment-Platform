using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SmartEmployment.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartEmployment.Services.Identity
{
	public class LoginModel
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<LoginModel> _logger;
		public LoginModel(SignInManager<User> signInManager,
			ILogger<LoginModel> logger,
			UserManager<User> userManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
		}

		public async Task OnGetAsync(string? returnUrl = null)
		{
			// Clear the existing external cookie to ensure a clean login process
			// await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
		}

		public async Task<bool> OnPostAsync(InputModel user)
		{
			var user1 = await _userManager.FindByNameAsync(user.Username);
			if (user == null || !await _userManager.CheckPasswordAsync(user1, user.Password))
				return false;
			// var signingCredentials = _jwtHandler.GetSigningCredentials();
			// var claims = _jwtHandler.GetClaims(user);
			// var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
			// var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
			return true;
		}
		public class InputModel
		{
			[Required]
			[EmailAddress]
			public string Username { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[Display(Name = "Remember me?")]
			public bool RememberMe { get; set; }
		}
	}
}
