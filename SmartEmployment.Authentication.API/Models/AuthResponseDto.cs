namespace SmartEmployment.Authentication.API.Models
{
	public class AuthResponseDto
	{
		public bool IsAuthSuccessful { get; set; }
		public string? ErrorMessage { get; set; }
		public string? Token { get; set; }
		public List<string> Roles { get; set; }
	}
}
