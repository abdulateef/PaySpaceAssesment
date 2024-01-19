using Moq;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Data;
using TaxCalculator.Data.Entities;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Infrastructure.Services;
using Shouldly;
using TaxCalculator.Core.Model;
using TaxCalculator.Data.Repositories;

namespace TaxCalculator.IntegrationTest.Cases
{
    public class TaxCalculatorServiceTests
	{
        private readonly Mock<ITaxRateManager> _taxRateManager;
        private readonly Mock<ITaxPostCodeManager> _taxPostCodeManager;
        private readonly Mock<ITaxTypeManager> _taxTypeManager;
        private readonly Mock<ICalculatedTaxeRepository> _calculatedTaxeRepository;
        private readonly TaxCalculatorService _taxCalculatorService;
        private  TaxPostCodeRepository _taxPostCodeRepository;

        public TaxCalculatorServiceTests()
        {
            _taxRateManager = new Mock<ITaxRateManager>();
            _taxTypeManager = new Mock<ITaxTypeManager>();
            _taxPostCodeManager = new Mock<ITaxPostCodeManager>();
            _calculatedTaxeRepository = new Mock<ICalculatedTaxeRepository>();

            _taxPostCodeManager.Setup(x => x.GetPostCode("00001"))
             .ReturnsAsync(new Tuple<bool, TaxPostCodeModel>(true, new TaxPostCodeModel { PostalCode = "00001", TaxType = 1 }));

            _taxCalculatorService = new TaxCalculatorService(_taxRateManager.Object,_taxPostCodeManager.Object,
                _calculatedTaxeRepository.Object, _taxTypeManager.Object);
        }

        [Fact]
        public async Task CalculateTax_Should_Return_Tax()
        {
            // Arrange
            decimal income = 100;
            string postCode = "00001";
            var dbOption = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("taxcalculator").Options;
            using var dbContext = new Context(dbOption);
            
                dbContext.Add(new TaxType { Id = 1, Type = "Progresive" });
                dbContext.Add(new TaxPostCode { Id = 1, TaxType = 1, PostalCode = postCode  });
                dbContext.Add(new TaxRate { Id = 1, From = 1000, To=0});
                await dbContext.SaveChangesAsync();
            
            _taxPostCodeRepository = new TaxPostCodeRepository(dbContext);

            var result =  _taxPostCodeRepository.GetPostCode(postCode);


            // Act
            var tax = await _taxCalculatorService.CalculateTax(income, postCode);

            // Assert
            tax.ShouldBe(299);
        }

        [Theory]
        [InlineData("0001","1")]
        [InlineData("0002", "2")]
        [InlineData("0003", "3")]
        public void Should_Return_InValid_TaxCode(string code, string taxType)
        {

        }

    }
}
