using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace SmartEmployment.Test
{
	public class UnitTest1
	{
		private readonly HttpClient _client; 

		public UnitTest1()
		{
			var appFactory = new WebApplicationFactory<Program>();
			_client = appFactory.CreateClient(); 
		}

		[Fact]
		public async Task Add_SavesTodoItem()
		{
			// arrange

			// act

			// assert 
		}
	}
}