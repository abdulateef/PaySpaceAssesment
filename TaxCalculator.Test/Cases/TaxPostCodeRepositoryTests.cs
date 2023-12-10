using System;
using Moq;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Test.Cases
{
	[TestFixture]
	public class TaxPostCodeTests
	{
        [Test]
        public async Task CreateTaxPostCode_ShouldReturnCreatedTaxPostCode()
        {
            // Arrange
            var taxPostCodeModel = new TaxPostCodeModel
            {
                PostalCode = "00000",
                TaxType = 1
            };
            var mockTaxPostCodeRepository = new Mock<ITaxPostCodeRepository>();
            mockTaxPostCodeRepository.Setup(repo => repo.Create(taxPostCodeModel))
                              .ReturnsAsync(new Tuple<bool, TaxPostCodeModel>(true, taxPostCodeModel));

            var taxPostCodeRepository = mockTaxPostCodeRepository.Object;

            // Act
            var result = await taxPostCodeRepository.Create(taxPostCodeModel);

            // Assert
            Assert.That(result.Item1, Is.EqualTo(true));
            Assert.That(result.Item2.PostalCode, Is.EqualTo("00000"));
        }

        [Test]
        public async Task UpdateTaxPostCode_ShouldReturnUpdatedTaxPostCode()
        {
            // Arrange
            string oldTaxPostCode = "00000";
            var taxPostCodeModel = new TaxPostCodeModel
            {
                PostalCode = "000001",
                TaxType = 1
            };
            var mockTaxPostCodeRepository = new Mock<ITaxPostCodeRepository>();
            mockTaxPostCodeRepository.Setup(repo => repo.Update(taxPostCodeModel, oldTaxPostCode))
                              .ReturnsAsync(new Tuple<bool, TaxPostCodeModel>(true, taxPostCodeModel));

            var taxPostCodeRepository = mockTaxPostCodeRepository.Object;

            // Act
            var result = await taxPostCodeRepository.Update(taxPostCodeModel, oldTaxPostCode);

            // Assert
            Assert.That(result.Item1, Is.EqualTo(true));
            Assert.That(result.Item2.PostalCode, Is.EqualTo("000001"));
        }

        [Test]
        public async Task DeleteTaxPostCode_ShouldReturnTrue()
        {
            // Arrange
            int taxPostCodeId = 1;
            var mockTaxPostCodeRepository = new Mock<ITaxPostCodeRepository>();
            mockTaxPostCodeRepository.Setup(repo => repo.Delete(taxPostCodeId))
                              .ReturnsAsync(true);

            var taxPostCodeRepository = mockTaxPostCodeRepository.Object;

            // Act
            var result = await taxPostCodeRepository.Delete(taxPostCodeId);

            // Assert
            Assert.That(result, Is.EqualTo(true));

        }

        [Test]
        public async Task GetTaxPostCode_ShouldReturnUpdatedTaxPostCode()
        {
            // Arrange
            string taxPostCode = "000000";
            var mockTaxPostCodeRepository = new Mock<ITaxPostCodeRepository>();
            mockTaxPostCodeRepository.Setup(repo => repo.GetPostCode(taxPostCode))
                              .ReturnsAsync(new Tuple<bool, TaxPostCodeModel>(true,
                              new TaxPostCodeModel {PostalCode = taxPostCode, TaxType = 1 }));
            
            var taxPostCodeRepository = mockTaxPostCodeRepository.Object;

            // Act
            var result = await taxPostCodeRepository.GetPostCode(taxPostCode);

            // Assert
            Assert.That(result.Item1, Is.EqualTo(true));
            Assert.That(result.Item2.PostalCode, Is.EqualTo("000000"));

        }
        [Test]
        public async Task GetAllTaxPostCode_ShouldReturnTrue()
        {
            // Arrange
            var mockTaxPostCodeRepository = new Mock<ITaxPostCodeRepository>();
            mockTaxPostCodeRepository.Setup(repo => repo.GetAll(1,20))
                              .ReturnsAsync(new Tuple<bool, TaxPostCodeModel[]>(true, new[]
                              {
                                  new TaxPostCodeModel{ PostalCode ="00001", TaxType = 1},
                                  new TaxPostCodeModel{ PostalCode ="00002", TaxType = 2},
                                  new TaxPostCodeModel{ PostalCode ="00003", TaxType = 3}

                              }));

            var taxPostCodeRepository = mockTaxPostCodeRepository.Object;

            // Act
            var result = await taxPostCodeRepository.GetAll(1,20);

            // Assert
            Assert.That(result.Item1, Is.EqualTo(true));
        }


    }
}

