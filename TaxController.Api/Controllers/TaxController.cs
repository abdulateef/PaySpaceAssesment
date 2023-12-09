using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Core.Interface;
using TaxCalculator.Core.Model;

namespace TaxController.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculatorService;
        public TaxController(ITaxCalculatorService taxCalculatorService)
		{
            _taxCalculatorService = taxCalculatorService;
		}

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([Required][FromBody] CalculateTaxModel calculateTaxModel)
        {
            var result = await _taxCalculatorService.CalculateTax(calculateTaxModel.Income, calculateTaxModel.PostCode);
            var response = new RespponseModel<decimal>
            {
                Message = "Calculated Successfully",
                RequestStatus = true,
                ResponseCode = "00",
                ResponseData = result
            };

            return Ok(response);
        }
    }
}

