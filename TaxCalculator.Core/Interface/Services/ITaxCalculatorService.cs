using System;
namespace TaxCalculator.Core.Interface
{
	public interface ITaxCalculatorService
	{
		Task<decimal> CalculateTax(decimal income, string poscode);
	}
}

