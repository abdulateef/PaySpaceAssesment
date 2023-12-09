using System;
using TaxCalculator.Core.Model;
using TaxCalculator.Data.Entities;

namespace TaxCalculator.Data.Mapping
{
	public static class Mapper
	{
		public static TaxPostCodeModel Map(this TaxPostCode model)
		{
			if (model == null)
			{
				return new TaxPostCodeModel();
			}

			return new TaxPostCodeModel
			{
				PostalCode = model.PostalCode,
				TaxType = model.TaxType
			};
		}


        public static TaxPostCode Map(this TaxPostCodeModel model)
        {
            if (model == null)
            {
                return new TaxPostCode();
            }

            return new TaxPostCode
            {
                PostalCode = model.PostalCode,
                TaxType = model.TaxType,
                CreatedAt = DateTime.Now,
                CreatedBy = "System",
            };
        }

        public static TaxRateModel Map(this TaxRate taxRate)
        {
            if (taxRate == null )
            {
                return new TaxRateModel();
            }

            return new TaxRateModel
            {
                From = taxRate.From,
                To = taxRate.To,
                RatePercentage = taxRate.RatePercentage
            };


        }

        public static TaxRate Map(this TaxRateModel taxRate)
        {
            if (taxRate == null)
            {
                return new TaxRate();
            }

            return new TaxRate
            {
                From = taxRate.From,
                To = taxRate.To,
                RatePercentage = taxRate.RatePercentage,
                CreatedAt = DateTime.Now,
                CreatedBy = "System"
            };


        }

        public static TaxType Map(this TaxTypeModel taxType)
        {
            if (taxType == null)
            {
                return new TaxType();
            }

            return new TaxType
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "System",
                Type = taxType.Type,
            };


        }

        public static TaxTypeModel Map(this TaxType taxType)
        {
            if (taxType == null)
            {
                return new TaxTypeModel();
            }

            return new TaxTypeModel
            {
           
                Type = taxType.Type,
            };


        }
    }
}

