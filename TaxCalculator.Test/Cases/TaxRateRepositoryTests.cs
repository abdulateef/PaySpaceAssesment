﻿using System;
using Moq;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Test.Cases
{
    [TestFixture]
    public class TaxRateTests
	{
        [Test]
        public async Task CreateTaxRate_ShouldReturnCreatedTaxRate()
        {
            // Arrange
            var taxRate = new TaxRateModel
            {
                From = 0,
                To = 1000,
                RatePercentage = 10
            };
            var mockTaxRateRepository = new Mock<ITaxRateRepositories>();
            mockTaxRateRepository.Setup(repo => repo.Create(taxRate))
                              .ReturnsAsync(new Tuple<bool, TaxRateModel>(true, taxRate));

            var taxRateRepository = mockTaxRateRepository.Object;

            // Act
            var result = await taxRateRepository.Create(taxRate);

            // Assert
            Assert.Equals(true, result.Item1);
            Assert.Equals(1000, result.Item2.From);
        }

        [Test]
        public async Task UpdateTaxRate_ShouldReturnCreatedTaxRate()
        {
            // Arrange
            int taxRateId = 1;
            var taxRate = new TaxRateModel
            {
                From = 1000,
                To = 100000,
                RatePercentage = 10
            };
            var mockTaxRateRepository = new Mock<ITaxRateRepositories>();
            mockTaxRateRepository.Setup(repo => repo.Update(taxRate, taxRateId))
                              .ReturnsAsync(new Tuple<bool, TaxRateModel>(true, taxRate));

            var taxRateRepository = mockTaxRateRepository.Object;

            // Act
            var result = await taxRateRepository.Update(taxRate, taxRateId);

            // Assert
            Assert.Equals(true, result.Item1);
            Assert.Equals(1000, result.Item2.From);
        }

        [Test]
        public async Task GetByIncome_ShouldReturnUpdatedTaxRate()
        {
            // Arrange
            decimal income = 1000;
            var taxRate = new TaxRateModel
            {
                From = 1000,
                To = 100000,
                RatePercentage = 10
            };
            var mockTaxRateRepository = new Mock<ITaxRateRepositories>();
            mockTaxRateRepository.Setup(repo => repo.GetByIncome(income))
                              .ReturnsAsync(new Tuple<bool, TaxRateModel>(true, taxRate));

            var taxRateRepository = mockTaxRateRepository.Object;

            // Act
            var result = await taxRateRepository.GetByIncome(income);

            // Assert
            Assert.Equals(true, result.Item1);
            Assert.Equals(1000, result.Item2.From);
        }

        [Test]
        public async Task DeleteTaxRate_ShouldReturnTrue()
        {
            // Arrange
            int id = 1;
            var mockTaxRateRepository = new Mock<ITaxRateRepositories>();
            mockTaxRateRepository.Setup(repo => repo.Delete(id))
                              .ReturnsAsync(true);

            var taxRateRepository = mockTaxRateRepository.Object;

            // Act
            var result = await taxRateRepository.Delete(id);

            // Assert
            Assert.Equals(true, result);
        }

        [Test]
        public async Task GetAllTaxRate_ShouldReturnTrue()
        {
            // Arrange
            int id = 1;
            var mockTaxRateRepository = new Mock<ITaxRateRepositories>();
            mockTaxRateRepository.Setup(repo => repo.GetAll())
                              .ReturnsAsync(new Tuple<bool, TaxRateModel[]>(true, new[]
                              {
                                  new TaxRateModel
                                    {
                                        From = 1000,
                                        To = 100000,
                                        RatePercentage = 20
                                    },
                                                          new TaxRateModel
                                    {
                                        From = 0,
                                        To = 100,
                                        RatePercentage = 10
                                    }
                              }));

            var taxRateRepository = mockTaxRateRepository.Object;

            // Act
            var result = await taxRateRepository.GetAll();

            // Assert
            Assert.Equals(true, result);
            Assert.Equals(1000, result.Item2[1].From);

        }
    }
}

