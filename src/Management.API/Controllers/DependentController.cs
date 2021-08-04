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
        public ActionResult<TransactionResponse> Post(InsertDependentRequest request)
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
    }
}
