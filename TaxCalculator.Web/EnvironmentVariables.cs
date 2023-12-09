using System;
namespace TaxCalculator.Web
{
	public static class EnvironmentVariables
	{
		public static string apiEndpoint { get; } = Environment.GetEnvironmentVariable("apiEndpoint");
	}
}

