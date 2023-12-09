using System;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Infrastructure.Manager
{
	public class TaxRateManager : ITaxRateManager
    {
        private readonly ITaxRateRepositories _taxRateRepositories;
        public TaxRateManager(ITaxRateRepositories taxRateRepositories)
		{
            _taxRateRepositories = taxRateRepositories;
        }

        public Task<Tuple<bool, TaxRateModel>> Create(TaxRateModel taxRateModel)
        {
            return _taxRateRepositories.Create(taxRateModel);
        }

        public Task<bool> Delete(int id)
        {
            return _taxRateRepositories.Delete(id);
        }

        public Task<Tuple<bool, TaxRateModel[]>> GetAll()
        {
            return _taxRateRepositories.GetAll();
        }

        public Task<Tuple<bool, TaxRateModel>> GetByIncome(decimal income)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<bool, TaxRateModel>> Update(TaxRateModel taxRateModel, int rateId)
        {
            return _taxRateRepositories.Update(taxRateModel,rateId);
        }
    }
}

