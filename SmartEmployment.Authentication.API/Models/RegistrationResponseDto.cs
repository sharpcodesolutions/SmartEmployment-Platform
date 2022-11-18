﻿namespace SmartEmployment.Authentication.API.Models
{
	public class RegistrationResponseDto
	{
		public bool IsSuccessfulRegistration { get; set; }
		public IEnumerable<string>? Errors { get; set; }
	}
}
