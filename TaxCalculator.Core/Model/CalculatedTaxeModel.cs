using System;
namespace TaxCalculator.Core.Model
{
	public class CalculatedTaxeModel
	{
        public decimal Tax { get; set; }
        public string PostCode { get; set; }
        public decimal Income { get; set; }
    }
}

