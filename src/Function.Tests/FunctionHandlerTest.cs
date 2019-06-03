using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Function.Tests
{
	public class FunctionHandlerTest
	{
		[Fact]
		public async Task HandlerAsyncTest()
		{
			IConfigurationBuilder builder = new ConfigurationBuilder();

			var configuration = builder.Build();
			var handler = new FunctionHandler();
			var result = await handler.HandleAsync("Test Data", configuration);
			Assert.Equal("Handler revived message Test Data", result);
		}
	}
}
