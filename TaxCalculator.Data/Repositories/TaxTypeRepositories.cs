using System;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;
using TaxCalculator.Data.Entities;
using TaxCalculator.Data.Mapping;

namespace TaxCalculator.Data.Repositories
{
	public class TaxTypeRepositories : ITaxTypeRepositories
    {
        private readonly Context _dbContext;

        public TaxTypeRepositories(Context context)
		{
            _dbContext = context;
		}

        public async Task<Tuple<bool, TaxTypeModel>> Create(string type)
        {
            try
            {
                if (string.IsNullOrEmpty(type))
                {
                    return new Tuple<bool, TaxTypeModel>(false, new TaxTypeModel());
                }
                TaxType taxType = new TaxType
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = "System",
                    Type = type,
                     
                };
                await _dbContext.TaxTypes.AddAsync(taxType);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return new Tuple<bool, TaxTypeModel>(true, taxType.Map());
                }

                return new Tuple<bool, TaxTypeModel>(false, new TaxTypeModel());

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, string>> Delete(string type)
        {
            try
            {
                var taxType = await _dbContext.TaxTypes.FirstOrDefaultAsync(x => x.Type.ToLower().Trim() == type.ToLower().Trim());
                if (taxType == null)
                {
                    return new Tuple<bool, string>(false, "Not Deleted");
                }
                _dbContext.TaxTypes.Remove(taxType);
                await _dbContext.SaveChangesAsync();
                return new Tuple<bool, string>(true, "Deleted");

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, TaxTypeModel[]>> GetAll(int page, int pageNumber)
        {
            page = page > 0 ? (page - 1) * pageNumber : 0;          
            var result = await _dbContext.TaxTypes.Select(x => x.Map()).Skip(page).Take(pageNumber).ToArrayAsync();
            return new Tuple<bool, TaxTypeModel[]>(true, result);
        }

        public async Task<Tuple<bool, TaxTypeModel>> GetById(int  typeId)
        {
            try
            {
                if (typeId < 0)
                {
                    return new Tuple<bool, TaxTypeModel>(false, new TaxTypeModel());
                }

                var result =  _dbContext.TaxTypes.FirstOrDefault(x => x.Id == typeId);
                if (result == null)
                {
                    return new Tuple<bool, TaxTypeModel>(false, new TaxTypeModel());

                }
                return new Tuple<bool, TaxTypeModel>(true, result.Map());

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Tuple<bool, TaxTypeModel>> Update(string oldtype, string newType)
        {
            try
            {
                if (string.IsNullOrEmpty(oldtype) || string.IsNullOrEmpty(newType))
                {
                    return new Tuple<bool, TaxTypeModel>(false, new TaxTypeModel());
                }
                var taxType = await _dbContext.TaxTypes.FirstOrDefaultAsync(x => x.Type.ToLower().Trim() == oldtype.ToLower().Trim());
                if (taxType != null)
                {
                    taxType.Type = newType;
                    taxType.UpdatedAt = DateTime.Now;
                    taxType.UpdatedBy = "System";
                    _dbContext.TaxTypes.Update(taxType);
                    await _dbContext.SaveChangesAsync();
                    return new Tuple<bool, TaxTypeModel>(true, taxType.Map());


                }
                return new Tuple<bool, TaxTypeModel>(false, new TaxTypeModel());

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

