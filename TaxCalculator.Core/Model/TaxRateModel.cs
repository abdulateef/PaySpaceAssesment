using System;
namespace TaxCalculator.Core.Model
{
	public class TaxRateModel
	{
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal RatePercentage { get; set; }
        public int Id { get; set; }
    }
}

