using System;
namespace TaxCalculator.Core.Model
{
	public class TaxPostCodeModel
    {
		public string PostalCode { get; set; }
		public int TaxType { get; set; } 
	}

    public class CreateTaxPostCodeModel
    {
        public string PostalCode { get; set; }
        public int TaxType { get; set; }
        public string oldPost { get; set; }
    }
}

