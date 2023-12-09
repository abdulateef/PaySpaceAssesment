using System;
namespace TaxCalculator.Data.Dto
{
	public class TaxRateModelDto
	{
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal RatePercentage { get; set; }
        public int Id { get; set; }
    }
}

