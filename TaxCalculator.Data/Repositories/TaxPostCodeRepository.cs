using System;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;
using TaxCalculator.Data.Entities;
using TaxCalculator.Data.Mapping;

namespace TaxCalculator.Data.Repositories
{
    public class TaxPostCodeRepository : ITaxPostCodeRepository
    {
        private readonly Context _dbContext;
        public TaxPostCodeRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tuple<bool, TaxPostCodeModel>> Create(TaxPostCodeModel taxPostCodeModel)
        {
            try
            {
                if (taxPostCodeModel == null)
                {
                    return new Tuple<bool, TaxPostCodeModel>(false, new TaxPostCodeModel());
                }               
                await _dbContext.TaxPostCodes.AddAsync(taxPostCodeModel.Map());
               var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return new Tuple<bool, TaxPostCodeModel>(true, taxPostCodeModel);
                                    }

                return new Tuple<bool, TaxPostCodeModel>(false, new TaxPostCodeModel());

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var taxPostalCode = await _dbContext.TaxPostCodes.FirstOrDefaultAsync(x => x.Id == id);
                if (taxPostalCode == null)
                {
                    return false;
                }
                _dbContext.TaxPostCodes.Remove(taxPostalCode);
               await _dbContext.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, TaxPostCodeModel[]>> GetAll(int page, int pageNumber)
        {
          var result =  await _dbContext.TaxPostCodes.Select(x => x.Map()).Skip(page).Take(pageNumber).ToArrayAsync();
            return new Tuple<bool, TaxPostCodeModel[]>(true, result);
        }

        public async Task<Tuple<bool, TaxPostCodeModel>> GetPostCode(string postCode)
        {
            try
            {
                if (string.IsNullOrEmpty(postCode))
                {
                    return new Tuple<bool, TaxPostCodeModel>(false, new TaxPostCodeModel());
                }
                var tax = await _dbContext.TaxPostCodes.FirstOrDefaultAsync(x => x.PostalCode == postCode);
                if (tax != null)
                {
                    return new Tuple<bool, TaxPostCodeModel>(true , tax.Map());
                }
                return new Tuple<bool, TaxPostCodeModel>(false, new TaxPostCodeModel());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, TaxPostCodeModel>> Update(TaxPostCodeModel taxPostCodeModel, string postCode)
        { 
            try
            {
                if (string.IsNullOrEmpty(taxPostCodeModel.PostalCode))
                {
                    return new Tuple<bool, TaxPostCodeModel>(false, new TaxPostCodeModel());
                }
                var taxPostalCode = await _dbContext.TaxPostCodes.FirstOrDefaultAsync(x => x.PostalCode == postCode);
                if (taxPostalCode != null)
                {
                    taxPostalCode.PostalCode = taxPostCodeModel.PostalCode;
                    taxPostalCode.TaxType = taxPostCodeModel.TaxType;
                    _dbContext.TaxPostCodes.Update(taxPostalCode);
                   await _dbContext.SaveChangesAsync();
                    return new Tuple<bool, TaxPostCodeModel>(true, taxPostalCode.Map());


                }
                return new Tuple<bool, TaxPostCodeModel>(false, new TaxPostCodeModel());

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

