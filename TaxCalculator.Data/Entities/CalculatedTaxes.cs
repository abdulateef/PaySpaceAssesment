using System;
namespace TaxCalculator.Data.Entities
{
	public class CalculatedTaxe : BaseEntity
	{
		public decimal Tax { get; set; }
		public string PostCode { get; set; }
		public decimal Income { get; set; }
	}
}

