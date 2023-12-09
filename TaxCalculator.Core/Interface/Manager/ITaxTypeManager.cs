using System;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Core.Interface.Manager
{
	public interface ITaxTypeManager
	{
        Task<Tuple<bool, TaxTypeModel>> Create(string type);
        Task<Tuple<bool, TaxTypeModel>> Update(string oldtype, string newType);
        Task<Tuple<bool, string>> Delete(string type);
        Task<Tuple<bool, TaxTypeModel>> GetById(int typeId);
        Task<Tuple<bool, TaxTypeModel[]>> GetAll(int page, int pageNumber);

    }
}

