using System;
namespace TaxCalculator.Data.Entities
{
	public class TaxPostCode : BaseEntity
    {
        public string PostalCode { get; set; }
        public int TaxType { get; set; }
    }
}

