using System;
namespace TaxCalculator.Data.Entities
{
	public class TaxRate : BaseEntity
	{
		public decimal From { get; set; }
        public decimal To { get; set; }
		public decimal RatePercentage { get; set; }
    }
}

