// Copyright (c) Alex Ellis 2017. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// Modified by Adam Holt 2019 to support Async Function

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Function;
using Microsoft.Extensions.Configuration;

namespace root
{
	class Program
	{
		static async Task Main(string[] args)
		{

			IConfiguration configuration = null;
			var configTask = Task.Run(() =>
			{
				IConfigurationBuilder builder = new ConfigurationBuilder();
				builder.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
				builder.AddYamlFile("app_config/appsettings.yml", true);

				configuration = builder.Build();
			});

			var inTask = Console.In.ReadToEndAsync();

			await Task.WhenAll (configTask, inTask);

			var buffer = inTask.Result;

			var f = new FunctionHandler();

			var responseValue = await f.HandleAsync(buffer, configuration);

			if (responseValue != null)
			{
				Console.Write(responseValue);
			}
		}
	}
}

