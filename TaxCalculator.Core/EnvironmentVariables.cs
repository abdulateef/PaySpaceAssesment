using System;
namespace TaxCalculator.Core
{
	public static class EnvironmentVariables
	{
		public static string ConnectionString { get; } = Environment.GetEnvironmentVariable("ConnectionString");
	}
}

