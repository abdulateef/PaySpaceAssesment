using System;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Infrastructure.Manager
{
    public class TaxTypeManager : ITaxTypeManager
    {
        private readonly ITaxTypeRepositories _taxTypeRepositories ;
        public TaxTypeManager(ITaxTypeRepositories taxTypeRepositories)
        {
            _taxTypeRepositories = taxTypeRepositories;
        }
        public Task<Tuple<bool, TaxTypeModel>> Create(string type)
        {
            return _taxTypeRepositories.Create(type);
        }

        public Task<Tuple<bool, string>> Delete(string type)
        {
            return _taxTypeRepositories.Delete(type);
        }

        public Task<Tuple<bool, TaxTypeModel[]>> GetAll(int page, int pageNumber)
        {
            return _taxTypeRepositories.GetAll(page, pageNumber);
        }

        public Task<Tuple<bool, TaxTypeModel>> GetById(int typeId)
        {
            return _taxTypeRepositories.GetById(typeId);
        }

        public Task<Tuple<bool, TaxTypeModel>> Update(string oldType, string newType)
        {
            return _taxTypeRepositories.Update(oldType, newType);
        }
    }
}

