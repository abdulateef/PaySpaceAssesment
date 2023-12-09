using System;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Core.Interface.Manager
{
	public interface ITaxPostCodeManager
	{
        Task<Tuple<bool, TaxPostCodeModel>> Create(TaxPostCodeModel taxPostCodeModel);
        Task<Tuple<bool, TaxPostCodeModel>> Update(TaxPostCodeModel taxPostCodeModel, string postCode);
        Task<bool> Delete(int id);
        Task<Tuple<bool, TaxPostCodeModel[]>> GetAll(int page, int pageNumber);
        Task<Tuple<bool, TaxPostCodeModel>> GetPostCode(string postCode);

    }
}

