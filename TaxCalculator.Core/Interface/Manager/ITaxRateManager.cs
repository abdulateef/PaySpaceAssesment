using System;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Core.Interface.Manager
{
	public interface ITaxRateManager
	{
        Task<Tuple<bool, TaxRateModel>> Create(TaxRateModel taxRateModel);
        Task<Tuple<bool, TaxRateModel>> Update(TaxRateModel taxRateModel, int rateId);
        Task<bool> Delete(int id);
        Task<Tuple<bool, TaxRateModel[]>> GetAll();
        Task<Tuple<bool, TaxRateModel>> GetByIncome(decimal income);

    }
}

