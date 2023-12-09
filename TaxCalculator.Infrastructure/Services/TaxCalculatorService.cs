using System;
using System.Reflection.Emit;
using TaxCalculator.Core.Interface;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Infrastructure.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxRateManager _taxRateManager;
        private readonly ITaxPostCodeManager _taxPostCodeManager;
        private readonly ITaxTypeManager _taxTypeManager;
        private readonly ICalculatedTaxeRepository _calculatedTaxeRepository;
        public TaxCalculatorService(ITaxRateManager taxRateManager, ITaxPostCodeManager taxPostCodeManager,
            ICalculatedTaxeRepository calculatedTaxeRepository,
            ITaxTypeManager taxTypeManager )
        {
            _taxRateManager = taxRateManager;
            _taxPostCodeManager = taxPostCodeManager;
            _taxTypeManager = taxTypeManager;
            _calculatedTaxeRepository = calculatedTaxeRepository;
        }
        public async Task<decimal> CalculateTax(decimal income, string postCode)
        {
            try
            {
                decimal tax = 0;
                if (string.IsNullOrWhiteSpace(postCode) || income < 0)
                {
                    throw new ArgumentException("postcode and income is required");
                }

                var taxType = await _taxPostCodeManager.GetPostCode(postCode);
                if (taxType == null)
                {
                    throw new ArgumentException("postcode does not have a tax type");
                }
                //get tax type
                var type = await _taxTypeManager.GetById(taxType.Item2.TaxType);
                if (!type.Item1)
                {
                    throw new ArgumentException("invalid tax type");
                }
                //get tax rate range
                var taxRate = await _taxRateManager.GetByIncome(income);
              
                switch (type.Item2.Type)
                {
                    case  "progressive":
                        var taxRateModel = taxRate.Item1 ? taxRate.Item2 : new TaxRateModel();
                        tax = await CalculateProgressiveTax(income, taxRateModel);
                        break;
                    case "flatrate":
                        tax = await CalculateFlatRateTax(income);
                        break;
                    case "flatvalue":
                        tax = await CalculateFlatValueTax(income);
                        break;
                    default:
                        break;
                }
                //log tax
              await  _calculatedTaxeRepository.Create(new CalculatedTaxeModel
                {
                    Income = income,
                    PostCode = postCode,
                    Tax = tax
                });
                return tax;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<decimal> CalculateProgressiveTax(decimal income, TaxRateModel taxRateModel)
        {
           
            decimal tax = 0;
            tax = (income * taxRateModel.RatePercentage)/100;

            return await Task.FromResult(tax);
        }

        private async Task<decimal> CalculateFlatValueTax(decimal income)
        {
            decimal tax = 0;

            if (income < 200000)
            {
                tax = (income * 5)/100;

            }
            else
            {
                tax = 10000;
            }


            return await Task.FromResult(tax);
        }

        private async Task<decimal> CalculateFlatRateTax(decimal income)
        {
            decimal tax = 0;
            tax = (income * (decimal)17.5) / 100;

            return await Task.FromResult(tax);
        }
    }
}

