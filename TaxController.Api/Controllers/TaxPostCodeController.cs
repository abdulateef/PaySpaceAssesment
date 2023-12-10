using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxPostCodeController : ControllerBase
    {
        private readonly ITaxPostCodeManager _taxPostCodeManager;
        private readonly ILogger<TaxPostCodeController> _logger;
        public TaxPostCodeController(ILogger<TaxPostCodeController> logger, ITaxPostCodeManager taxPostCodeManager)
        {
            _taxPostCodeManager = taxPostCodeManager;
            _logger = logger;
        }

        [HttpPost("CreateTaxPostCode")]
        public async Task<IActionResult> Create([Required][FromBody] TaxPostCodeModel taxPostCodeModel)
        {
            var (success, result) = await _taxPostCodeManager.Create(taxPostCodeModel);
            if (success)
            {
                var response = new RespponseModel<TaxPostCodeModel>
                {
                    Message = "Created Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxPostCodeModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }

        [HttpPut("UpdateTaxPostCode")]
        public async Task<IActionResult> Update([Required][FromBody] CreateTaxPostCodeModel createTaxPostCodeModel)
        {
            var (success, result) = await _taxPostCodeManager.Update(new
                TaxPostCodeModel
            { PostalCode= createTaxPostCodeModel.PostalCode,
                TaxType = createTaxPostCodeModel.TaxType}, createTaxPostCodeModel.oldPost);
            if (success)
            {
                var response = new RespponseModel<TaxPostCodeModel>
                {
                    Message = "Updated Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxPostCodeModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }

        [HttpDelete("DeleteTaxPostCode")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _taxPostCodeManager.Delete(id);
            if (success)
            {
                var response = new RespponseModel<string>
                {
                    Message = "Deleted Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = null
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<string>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = null
            });
        }

        [HttpGet("GetAllTaxPostCodes")]
        public async Task<IActionResult> GetAll(int page, int pageNumber)
        {
            var (success, result) = await _taxPostCodeManager.GetAll(page, pageNumber);
            if (success)
            {
                var response = new RespponseModel<TaxPostCodeModel[]>
                {
                    Message = "Retrieved Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxPostCodeModel[]>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }


    }
}

