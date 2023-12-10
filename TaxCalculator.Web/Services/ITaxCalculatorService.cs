using System;
using TaxCalculator.Web.Model;

namespace TaxCalculator.Web.Services
{
	public interface ITaxCalculatorService
	{
		Task<RespponseModel> Calculate(string postCode, decimal Income);
	}
}

