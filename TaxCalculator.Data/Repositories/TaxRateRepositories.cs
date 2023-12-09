using System;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;
using TaxCalculator.Data.Dto;
using TaxCalculator.Data.Entities;
using TaxCalculator.Data.Mapping;

namespace TaxCalculator.Data.Repositories
{
	public class TaxRateRepositories : ITaxRateRepositories
    {
        private readonly Context _dbContext;

        public TaxRateRepositories(Context dbContext)
		{
            _dbContext = dbContext;
        }

        public async Task<Tuple<bool, TaxRateModel>> Create(TaxRateModel taxRateModel)
        {
            if (taxRateModel == null)
            {
                return new Tuple<bool, TaxRateModel>(false, new TaxRateModel());
            }
            await _dbContext.TaxRates.AddAsync(taxRateModel.Map());
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return new Tuple<bool, TaxRateModel>(true, taxRateModel);
            }

            return new Tuple<bool, TaxRateModel>(false, new TaxRateModel());
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var taxRate = await _dbContext.TaxRates.FirstOrDefaultAsync(x => x.Id == id);
                if (taxRate == null)
                {
                    return false;
                }
                _dbContext.TaxRates.Remove(taxRate);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, TaxRateModel[]>> GetAll()
        {
            var result = await _dbContext.TaxRates.Select(x => x.Map()).ToArrayAsync();
            return new Tuple<bool, TaxRateModel[]>(true, result);
        }

        public async Task<Tuple<bool, TaxRateModel>> GetByIncome(decimal income)
        {
            try
            {
                if (income < 0)
                {
                    return new Tuple<bool, TaxRateModel>(false, new TaxRateModel());
                }
                var taxRate = await _dbContext.TaxRates.FirstOrDefaultAsync(x => x.From >=  income && x.To  <= income);
                return new Tuple<bool, TaxRateModel>(true, taxRate.Map());


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, TaxRateModel>> Update(TaxRateModel taxRateModel, int taxRateId)
        {
            try
            {
                
                var taxRate = await _dbContext.TaxRates.FirstOrDefaultAsync(x => x.Id == taxRateId);
                if (taxRate != null)
                {
                    taxRate.RatePercentage = taxRateModel.RatePercentage;
                    taxRate.From = taxRate.From;
                    taxRate.To = taxRateModel.To;
                    taxRate.UpdatedAt = DateTime.Now;
                    taxRate.UpdatedBy = "System";
                    _dbContext.TaxRates.Update(taxRate);
                    await _dbContext.SaveChangesAsync();
                    return new Tuple<bool, TaxRateModel>(true, taxRate.Map());


                }
                return new Tuple<bool, TaxRateModel>(false, new TaxRateModel());

            }
            catch (Exception ex)
            {
                throw;
            }
        }

      

     
    }
}

