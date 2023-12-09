using TaxCalculator.Core.Model;

namespace TaxCalculator.Core.Interface.Repositories
{
    public interface ICalculatedTaxeRepository
	{
		Task<Tuple<bool, CalculatedTaxeModel>> Create(CalculatedTaxeModel model); 
	}
}

