using System;
using Management.API.Request;
using Management.API.Response;
using Management.Domain;
using Management.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service, ILogger<EmployeeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint to insert Employee.
        /// </summary>
        /// <param name="request">Employee information</param>
        /// <returns>TransactionResponse</returns>
        [HttpPost]
        public ActionResult<TransactionResponse> Post(EmployeeDataRequest request)
        {

            if (request is null)
                return BadRequest();

            try
            {
                _service.Insert(new Employee(null, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender,
              request.Cpf, request.PhoneNumber, request.Address, request.IsActive, null));

                return Ok(new TransactionResponse(new ResultTransaction(true)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }

        }

        /// <summary>
        /// Endpoint to get all Employees
        /// </summary>
        /// <returns>EmployeeListResponse</returns>
        [HttpGet]
        public ActionResult<EmployeeListResponse> Get()
        {
            try
            {
                return Ok(new EmployeeListResponse(_service.Get()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }

        /// <summary>
        /// Endpoint to get Employee by id.
        /// </summary>
        /// <param name="id">Employee's id</param>
        /// <returns>EmployeeResponse</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<EmployeeResponse> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            try
            {
                return Ok(new EmployeeResponse(_service.Get(id)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }

        /// <summary>
        /// Endpoint to delete Employee by id.
        /// </summary>
        /// <param name="id">Employee's id</param>
        /// <returns>EmployeeResponse</returns>
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
        /// Endpoint to update Employee by id.
        /// </summary>
        /// <param name="request">Employee's data</param>
        /// <param name="id">emplyee's id</param>
        /// <returns>TransactionResponse</returns>
        [HttpPut]
        [Route("{id}")]
        public ActionResult<TransactionResponse> Put(EmployeeDataRequest request, int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            try
            {
                return Ok(new TransactionResponse(new ResultTransaction(_service.Update(new Employee(id, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender,
                    request.Cpf, request.PhoneNumber, request.Address, request.IsActive, null), id))));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(string.Empty, ex.Message));
            }
        }
    }
}
