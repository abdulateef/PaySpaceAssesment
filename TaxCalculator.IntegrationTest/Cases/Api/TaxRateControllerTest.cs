
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TaxCalculator.Api.Controllers;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;
using TaxCalculator.Data;
using TaxCalculator.Data.Repositories;
using TaxCalculator.Infrastructure.Manager;

namespace TaxCalculator.IntegrationTest.Cases.Api
{
	public class TaxRateControllerTest
	{
		private readonly Mock<ITaxRateManager> _mockManager;
        private readonly Mock<ITaxRateRepository> _taxRateRepo;
		private readonly Mock<ILogger<TaxRateController>> _mockLogger;
		private readonly TaxRateController _taxRateController;
        private  TaxRateModel _request;
        private  Tuple<bool, TaxRateModel> _result;
        public TaxRateControllerTest()
		{
            _taxRateRepo = new Mock<ITaxRateRepository>();
            _mockLogger = new Mock<ILogger<TaxRateController>>();
			_mockManager = new Mock<ITaxRateManager>();
			_taxRateController = new TaxRateController(_mockLogger.Object, _mockManager.Object);
            _request = new TaxRateModel
            {
                From = 10,
                To = 100,
                RatePercentage = 10
            };
            _result = new Tuple<bool, TaxRateModel>(true, _request);
            _mockManager.Setup(x => x.Create(_request)).ReturnsAsync(_result);
            _taxRateRepo.Setup(x => x.Create(_request)).ReturnsAsync(_result);

        }

        [Fact]
        public async Task Should_Return_OkObject()
        {
           
            //act
            var result = await _taxRateController.CreateTaxType(_request);


            //assert
            _mockManager.Verify(x => x.Create(_request), Times.Once);
            _taxRateRepo.Verify(x => x.Create(_request), Times.Once);
            result.ShouldNotBeNull();
            result.ShouldNotBeOfType<BadRequestObjectResult>();
            result.ShouldBeOfType<OkObjectResult>();

        }


        [Fact]
        public async Task Should_Return_BadRequestObject()
        {
            //arrange
            _request.To = 0;
            _result = new Tuple<bool, TaxRateModel>(false, _request);
            _mockManager.Setup(x => x.Create(_request)).ReturnsAsync(_result);
            _taxRateRepo.Setup(x => x.Create(_request)).ReturnsAsync(_result);

            //act
            var result = await _taxRateController.CreateTaxType(_request);


            //assert
            _mockManager.Verify(x => x.Create(_request), Times.Once);
            _taxRateRepo.Verify(x => x.Create(_request), Times.Once);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<BadRequestObjectResult>();
            result.ShouldNotBeOfType<OkObjectResult>();
        }
    }
}

