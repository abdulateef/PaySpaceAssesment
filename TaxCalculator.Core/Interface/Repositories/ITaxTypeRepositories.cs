using System;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Core.Interface.Repositories
{
	public interface  ITaxTypeRepositories
	{
		Task<Tuple<bool, TaxTypeModel>> Create(string type);
        Task<Tuple<bool, TaxTypeModel>> Update(string Oldtype, string newType);
        Task<Tuple<bool, string>> Delete(string type);
        Task<Tuple<bool, TaxTypeModel>> GetById(int typeId);
        Task<Tuple<bool, TaxTypeModel[]>> GetAll(int page, int pageNumber);


    }
}

