using System;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;
using TaxCalculator.Data.Mapping;

namespace TaxCalculator.Data.Repositories
{
	public class CalculatedTaxeRepository : ICalculatedTaxeRepository
    {
        private readonly Context _dbContext;
        public CalculatedTaxeRepository(Context context)
		{
            _dbContext = context;
		}

        public async Task<Tuple<bool, CalculatedTaxeModel>> Create(CalculatedTaxeModel model)
        {
            try
            {
                if (model == null)
                {
                    return new Tuple<bool, CalculatedTaxeModel>(false, new CalculatedTaxeModel());
                }
                await _dbContext.CalculatedTaxes.AddAsync(model.Map());
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    return new Tuple<bool, CalculatedTaxeModel>(true, model);
                }

                return new Tuple<bool, CalculatedTaxeModel>(false, new CalculatedTaxeModel());

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

