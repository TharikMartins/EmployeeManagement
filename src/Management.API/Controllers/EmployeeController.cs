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
        public ActionResult<TransactionResponse> Post(InsertEmployeeRequest request)
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
        /// Endpoint to get Employee by id.
        /// </summary>
        /// <param name="id">Employee's id</param>
        /// <returns>EmployeeResponse</returns>
        [HttpGet]
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
    }
}
