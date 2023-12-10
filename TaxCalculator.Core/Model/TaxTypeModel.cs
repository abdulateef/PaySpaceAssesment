using System;
using TaxCalculator.Core.Enum;

namespace TaxCalculator.Core.Model
{
	public class TaxTypeModel
    {
		public string Type { get; set; }
        public long Id { get; set; }
    }

    public class CreateTaxTypeModel
    {
        public string OldType { get; set; }
        public string NewType { get; set; }

    }
}

