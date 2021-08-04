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
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(InsertEmployeeRequest request)
        {

            if (request is null)
                return BadRequest();

            try
            {
                _service.Insert(new Employee(request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender,
              request.Cpf, request.PhoneNumber, request.Address, request.IsActive, null));

                return Ok(new TransactionResponse(true));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} , {ex.StackTrace}");

                return StatusCode(500, new ErrorResponse(ex.Message));
            }

        }
    }
}
