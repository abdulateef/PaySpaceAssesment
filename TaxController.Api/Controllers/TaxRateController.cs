
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Model;
using TaxCalculator.Infrastructure.Manager;

namespace TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxRateController : ControllerBase
    {
        private readonly ITaxRateManager _taxRateManager;
        private readonly ILogger<TaxRateController> _logger;
        public TaxRateController(ILogger<TaxRateController> logger, ITaxRateManager taxRateManager)
        {
            _logger = logger;
            _taxRateManager = taxRateManager;
        }

        [HttpPost("CreateTaxRate")]
        public async Task<IActionResult> Create([Required][FromBody] TaxRateModel taxRateModel)
        {
            var (success, result) = await _taxRateManager.Create(taxRateModel);
            if (success)
            {
                var response = new RespponseModel<TaxRateModel>
                {
                    Message = "Created Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxRateModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }

        [HttpPut("UpdateTaxRate")]
        public async Task<IActionResult> Update([Required][FromBody] TaxRateModel taxRateModel)
        {
            var (success, result) = await _taxRateManager.Update(taxRateModel, taxRateModel.Id);
            if (success)
            {
                var response = new RespponseModel<TaxRateModel>
                {
                    Message = "Updated Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxRateModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }

        [HttpDelete("DeleteTaxRate")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _taxRateManager.Delete(id);
            if (success)
            {
                var response = new RespponseModel<TaxRateModel>
                {
                    Message = "Deleted Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = null
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxRateModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = null
            });
        }

        [HttpGet("GetAllTaxRates")]
        public async Task<IActionResult> GetAll(int page, int pageNumber)
        {
            var (success, result) = await _taxRateManager.GetAll();
            if (success)
            {
                var response = new RespponseModel<TaxRateModel[]>
                {
                    Message = "Retrieved Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxRateModel[]>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }


    }
}

