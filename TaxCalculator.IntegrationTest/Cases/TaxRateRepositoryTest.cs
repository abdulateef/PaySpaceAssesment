using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Moq;
using Shouldly;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;
using TaxCalculator.Data;
using TaxCalculator.Data.Repositories;

namespace TaxCalculator.IntegrationTest.Cases
{
	public class TaxRateRepositoryTest
	{
		private readonly DbContextOptions<Context> _dbContextOptions;
		private readonly Mock<ITaxRateRepository> _mockTaxrateRepository;
        public TaxRateRepositoryTest()
		{
            _dbContextOptions = new DbContextOptionsBuilder<Context>().UseInMemoryDatabase("taxcalculator").Options;
			_mockTaxrateRepository = new Mock<ITaxRateRepository>();
        }

		[Fact]
		public async Task Should_Return_Created_TaxRate()
		{
			//arrange
			var model = new TaxRateModel
			{
				From = 10,
				To = 100,
				RatePercentage = 10
			};
            using var dbContext = new Context(_dbContextOptions);
            var taxRateRepository = new TaxRateRepository(dbContext);
            _mockTaxrateRepository.Setup(q => q.Create(It.IsAny<TaxRateModel>()));


            //act
            var result = await taxRateRepository.Create(model);


			//assert
            result.ShouldNotBeNull();
            result.Item1.ShouldBe(true);
            result.Item2.From.ShouldBe(10);
            result.Item2.To.ShouldBe(100);


        }
        [Fact]
        public async Task Should_Return_TaxRates()
        {
            //arrange
            var model = new TaxRateModel
            {
                From = 10,
                To = 100,
                RatePercentage = 10
            };
            using var dbContext = new Context(_dbContextOptions);
            var taxRateRepository = new TaxRateRepository(dbContext);
            _mockTaxrateRepository.Setup(q => q.Create(It.IsAny<TaxRateModel>()));
          
            await taxRateRepository.Create(model); //create a sample record because we are using inmemomory

            //act
            var result = await taxRateRepository.GetAll();


            //assert
            result.ShouldNotBeNull();
            result.Item1.ShouldBe(true);
            result.Item2.Count().ShouldBeGreaterThanOrEqualTo(1);
            result.Item2[0].To.ShouldBe(100);


        }

        [Theory]
        [InlineData(10,100,10)]
        [InlineData(101, 200, 20)]
        [InlineData(201, 300, 30)]
        [InlineData(301, 400, 40)]
        public async Task Should_Return_All_Created_TaxRates(decimal from, decimal to, decimal percentage)
        {
            //arrange
            var model = new TaxRateModel {From = from,To = to, RatePercentage = percentage};
            var model2 = new TaxRateModel { From = from, To = to, RatePercentage = percentage };
            var model3 = new TaxRateModel { From = from, To = to, RatePercentage = percentage };
            var model4 = new TaxRateModel { From = from, To = to, RatePercentage = percentage };

            using var dbContext = new Context(_dbContextOptions);
            var taxRateRepository = new TaxRateRepository(dbContext);

            //create a sample record because we are using inmemomory
            await taxRateRepository.Create(model); 
            await taxRateRepository.Create(model2); 
            await taxRateRepository.Create(model3); 
            await taxRateRepository.Create(model4); 

            //act
            var result = await taxRateRepository.GetAll();

            //assert
            result.ShouldNotBeNull();
            result.Item1.ShouldBe(true);
            result.Item2.Count().ShouldBe(4);

        }


        [Fact]
        public async Task Should_Return_Updated_TaxRate()
        {
            //arrange
            var model = new TaxRateModel
            {
                From = 10,
                To = 100,
                RatePercentage = 10
            };
            var update = new TaxRateModel
            {
                From = 11,
                To = 101,
                RatePercentage = 10
            };
            using var dbContext = new Context(_dbContextOptions);
            var taxRateRepository = new TaxRateRepository(dbContext);
            _mockTaxrateRepository.Setup(q => q.Create(It.IsAny<TaxRateModel>()));

            await taxRateRepository.Create(model); //create a sample record because we are using inmemomory

            //act
            var creeatedTaxRate = await taxRateRepository.GetByIncome(10);
            var result = await taxRateRepository.Update(update, creeatedTaxRate.Item2.Id);


            //assert
            result.ShouldNotBeNull();
            result.Item1.ShouldBe(true);
            result.Item2.From.ShouldBe(11);
            result.Item2.To.ShouldBe(101);

        }

        [Fact]
        public async Task Should_Return_True_After_Deleting_TaxRate()
        {
            //arrange
            var model = new TaxRateModel
            {
                From = 10,
                To = 100,
                RatePercentage = 10
            };
         
            using var dbContext = new Context(_dbContextOptions);
            var taxRateRepository = new TaxRateRepository(dbContext);
            _mockTaxrateRepository.Setup(q => q.Create(It.IsAny<TaxRateModel>()));

            await taxRateRepository.Create(model); //create a sample record because we are using inmemomory

            //act
            var creeatedTaxRate = await taxRateRepository.GetByIncome(10);
            var result = await taxRateRepository.Delete(creeatedTaxRate.Item2.Id);


            //assert
            result.ShouldBe(true);
        }

        public static IEnumerable<object[]> TaxRateData()
        {
            yield return new object[] { 10,100, 10   };
            yield return new object[] { 11, 200, 20  };
            yield return new object[] {  21, 300, 30 };
        }


        [Theory]
        [MemberData(nameof(TaxRateData))]
        public async Task Should_Return_Created_TaxRates(decimal from, decimal to, decimal percentage)
        {
            //arrange
            var model = new TaxRateModel { From = from, To = to, RatePercentage = percentage };
            var model2 = new TaxRateModel { From = from, To = to, RatePercentage = percentage };
            var model3 = new TaxRateModel { From = from, To = to, RatePercentage = percentage };

            using var dbContext = new Context(_dbContextOptions);
            var taxRateRepository = new TaxRateRepository(dbContext);

            //create a sample record because we are using inmemomory
            await taxRateRepository.Create(model);
            await taxRateRepository.Create(model2);
            await taxRateRepository.Create(model3);

            //act
            var result = await taxRateRepository.GetAll();

            //assert
            result.ShouldNotBeNull();
            result.Item1.ShouldBe(true);
            result.Item2.Count().ShouldBe(3);

        }

        
    }
}

