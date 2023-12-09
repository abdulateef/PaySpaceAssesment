using System;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Infrastructure.Manager
{
	public class TaxPostCodeManager : ITaxPostCodeManager
    {
        private readonly ITaxPostCodeRepository _taxPostCodeRepository;
        public TaxPostCodeManager(ITaxPostCodeRepository taxPostCodeRepository)
		{
            _taxPostCodeRepository = taxPostCodeRepository;
		}

        public Task<Tuple<bool, TaxPostCodeModel>> Create(TaxPostCodeModel taxPostCodeModel)
        {
            return _taxPostCodeRepository.Create(taxPostCodeModel);
        }

        public Task<bool> Delete(int id)
        {
            return _taxPostCodeRepository.Delete(id);
        }

        public Task<Tuple<bool, TaxPostCodeModel[]>> GetAll(int page, int pageNumber)
        {
            return _taxPostCodeRepository.GetAll(page, pageNumber);
        }

        public Task<Tuple<bool, TaxPostCodeModel>> GetPostCode(string postCode)
        {
            return _taxPostCodeRepository.GetPostCode(postCode);
        }

        public Task<Tuple<bool, TaxPostCodeModel>> Update(TaxPostCodeModel taxPostCodeModel, string postCode)
        {
            return _taxPostCodeRepository.Update(taxPostCodeModel, postCode);
        }
    }
}

