using Management.API.Request;
using Management.API.Response;
using Management.Domain;
using Management.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependentController : Controller
    {
        private readonly ILogger<DependentController> _logger;
        private readonly DependentService _service;
        public DependentController(DependentService service, ILogger<DependentController> logger)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Endpoint responsible to insert dependent
        /// </summary>
        /// <param name="request">Dependent user data</param>
        /// <returns>TransactionResponse</returns>
        [HttpPost]
        public ActionResult<TransactionResponse> Post(DependentDataRequest request)
        {
            if (request is null)
                return BadRequest("Request cannot be null");

            try
            {
                _service.Insert(new Dependent(null, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender, request.EmployeeId));

                return Ok(new TransactionResponse(new ResultTransaction(true)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}, {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
           
        }

        /// <summary>
        /// Endpoint to get all Dependent
        /// </summary>
        /// <returns>DependentListResponse</returns>
        [HttpGet]
        public ActionResult<DependentListResponse> Get()
        {
            try
            {
                return Ok(new DependentListResponse(_service.Get()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }

        /// <summary>
        /// Endpoint to get Dependent by id.
        /// </summary>
        /// <param name="id">Dependent's id</param>
        /// <returns>DependentResponse</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<DependentResponse> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            try
            {
                return Ok(new DependentResponse(_service.Get(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }

        /// <summary>
        /// Endpoint to delete Dependent by id.
        /// </summary>
        /// <param name="id">Dependent's id</param>
        /// <returns>TransactionResponse</returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<TransactionResponse> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            try
            {
                return Ok(new TransactionResponse(new ResultTransaction(_service.Delete(id))));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }

        /// <summary>
        /// Endpoint to update Dependent by id.
        /// </summary>
        /// <param name="request">Dependent's data</param>
        /// <param name="id">Dependent's id</param>
        /// <returns>TransactionResponse</returns>
        [HttpPut]
        [Route("{id}")]
        public ActionResult<TransactionResponse> Put(DependentDataRequest request, int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            try
            {
                return Ok(new TransactionResponse(new ResultTransaction(_service.Update(new Dependent(id, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender, request.EmployeeId), id))));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }
    }
}
