using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Domain.Dtos.Wallet;
using App.Domain.Interfaces.Services.Wallet;
using App.Service.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _service;

        public WalletController(IWalletService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetWalletById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var result = await _service.GetById(id); 

                if (result != null)
                    return Ok(result);

                return NoContent();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("User/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(await _service.GetByUser(userId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                throw;
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] WalletDtoCreate wallet)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity();

                var result = await _service.Insert(wallet);

                if (result == null)
                    return BadRequest();

                var _url = Url.Link("GetWalletById", new { id = result.Id });

                if (string.IsNullOrEmpty(_url))
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Não foi possível gerar a URL para retorno dos dados inseridos.");

                return Created(new Uri(_url), result);
            }
            catch (WalletException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] WalletDtoUpdate wallet)
        {
            try
            {
                if (!ModelState.IsValid)
                    return UnprocessableEntity();

                var result = await _service.Update(wallet);

                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (WalletException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                return Ok(await _service.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}