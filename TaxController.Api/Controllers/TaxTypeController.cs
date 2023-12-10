using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Model;

namespace TaxCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxTypeController : ControllerBase
    {
        private readonly ITaxTypeManager _taxTypeManager;
        private readonly ILogger<TaxTypeController> _logger;

        public TaxTypeController(ILogger<TaxTypeController> logger, ITaxTypeManager taxTypeManager)
        {
            _logger = logger;
            _taxTypeManager = taxTypeManager;
        }

        [HttpPost("CreateTaxType")]
        public async Task<IActionResult> Create([Required][FromBody] TaxTypeModel taxTypeModel)
        {
            var (success, result) = await _taxTypeManager.Create(taxTypeModel.Type);
            if (success)
            {
                var response = new RespponseModel<TaxTypeModel>
                {
                    Message = "Created Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxTypeModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }

        [HttpPut("UpdateTaxType")]
        public async Task<IActionResult> Update([Required][FromBody] CreateTaxTypeModel taxTypeModel)
        {
            var (success, result) = await _taxTypeManager.Update(taxTypeModel.OldType, taxTypeModel.NewType);
            if (success)
            {
                var response = new RespponseModel<TaxTypeModel>
                {
                    Message = "Updated Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxTypeModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = result
            });
        }

        [HttpDelete("DeleteTaxType")]
        public async Task<IActionResult> Delete([Required][FromBody] TaxTypeModel taxTypeModel)
        {
            var (success, result) = await _taxTypeManager.Delete(taxTypeModel.Type);
            if (success)
            {
                var response = new RespponseModel<TaxTypeModel>
                {
                    Message = "Deleted Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = null
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxTypeModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = null
            });
        }

        [HttpGet("GetAllTaxTypes")]
        public async Task<IActionResult> GetAll(int page, int pageNumber)
        {
            var (success, result) = await _taxTypeManager.GetAll(page, pageNumber);
            if (success)
            {
                var response = new RespponseModel<TaxTypeModel[]>
                {
                    Message = "Retrieved Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = result
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxTypeModel[]>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = null
            });
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(int page, int pageNumber)
        {
            var (success, result) = await _taxTypeManager.GetAll(page, pageNumber);
            if (success)
            {
                var response = new RespponseModel<TaxTypeModel>
                {
                    Message = "Retrieved Successfully",
                    RequestStatus = success,
                    ResponseCode = "00",
                    ResponseData = null
                };

                return Ok(response);
            }

            return BadRequest(new RespponseModel<TaxTypeModel>
            {
                Message = "Failed",
                RequestStatus = success,
                ResponseCode = "01",
                ResponseData = null
            });
        }
    }
}

