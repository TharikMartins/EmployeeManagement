using Management.API.Request;
using Management.API.Response;
using Management.Domain;
using Management.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IService<Employee> _service;
        public EmployeeController(IService<Employee> service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint to insert Employee.
        /// </summary>
        /// <param name="request">Employee information</param>
        /// <returns>TransactionResponse</returns>
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> Post(EmployeeDataRequest request)
        {

            if (request is null)
                return BadRequest();

            await _service.Insert(new Employee(null, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender,
          request.Cpf, request.PhoneNumber, request.Address, request.IsActive, null));

            return Ok(new TransactionResponse(new ResultTransaction(true)));
        }

        /// <summary>
        /// Endpoint to get all Employees
        /// </summary>
        /// <returns>EmployeeListResponse</returns>
        [HttpGet]
        public async Task<ActionResult<EmployeeListResponse>> Get()
        {
            return Ok(new EmployeeListResponse(await _service.Get()));
        }

        /// <summary>
        /// Endpoint to get Employee by id.
        /// </summary>
        /// <param name="id">Employee's id</param>
        /// <returns>EmployeeResponse</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EmployeeResponse>> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            return Ok(new EmployeeResponse(await _service.Get(id)));
        }

        /// <summary>
        /// Endpoint to delete Employee by id.
        /// </summary>
        /// <param name="id">Employee's id</param>
        /// <returns>TransactionResponse</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<TransactionResponse>> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            return Ok(new TransactionResponse(new ResultTransaction(await _service.Delete(id))));
        }

        /// <summary>
        /// Endpoint to update Employee by id.
        /// </summary>
        /// <param name="request">Employee's data</param>
        /// <param name="id">Employee's id</param>
        /// <returns>TransactionResponse</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<TransactionResponse>> Put(EmployeeDataRequest request, int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            return Ok(new TransactionResponse(new ResultTransaction(await _service.Update(new Employee(id, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender,
                request.Cpf, request.PhoneNumber, request.Address, request.IsActive, null), id))));
        }
    }
}
