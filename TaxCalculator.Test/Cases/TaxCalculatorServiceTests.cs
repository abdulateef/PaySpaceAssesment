using System;
using Moq;
using TaxCalculator.Core.Interface;
using NUnit.Framework;


namespace TaxCalculator.Test.Cases
{
    [TestFixture]
    public class TaxCalculatorServiceTests
	{


        [Test]
        public async Task CalculateTax_ShouldReturnTax()
        {
            // Arrange
            decimal income = 100;
            string postCode = "00001";
            var mockTaxCalculatorService = new Mock<ITaxCalculatorService>();
            mockTaxCalculatorService.Setup(repo => repo.CalculateTax(income,postCode))
                              .ReturnsAsync(299);

            var taxCalculator = mockTaxCalculatorService.Object;

            // Act
            var tax = await taxCalculator.CalculateTax(income, postCode);

            // Assert
            Assert.That(tax, Is.EqualTo(299));

        }
    }
}

