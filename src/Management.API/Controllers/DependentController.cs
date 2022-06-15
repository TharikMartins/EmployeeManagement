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
    public class DependentController : Controller
    {
        private readonly IService<Dependent> _service;
        public DependentController(IService<Dependent> service)
        {
            _service = service;
        }

        /// <summary>
        /// Endpoint responsible to insert dependent
        /// </summary>
        /// <param name="request">Dependent user data</param>
        /// <returns>TransactionResponse</returns>
        [HttpPost]
        public async Task<ActionResult<TransactionResponse>> Post(DependentDataRequest request)
        {
            if (request is null)
                return BadRequest("Request cannot be null");


            await _service.Insert(new Dependent(null, request.Name, request.BirthDate, (Domain.Enum.Gender)request.Gender, request.EmployeeId));

            return Ok(new TransactionResponse(new ResultTransaction(true)));
        }

        /// <summary>
        /// Endpoint to get all Dependent
        /// </summary>
        /// <returns>DependentListResponse</returns>
        [HttpGet]
        public async Task<ActionResult<DependentListResponse>> Get() => Ok(new DependentListResponse(await _service.Get()));

        /// <summary>
        /// Endpoint to get Dependent by id.
        /// </summary>
        /// <param name="id">Dependent's id</param>
        /// <returns>DependentResponse</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DependentResponse>> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            return Ok(new DependentResponse(await _service.Get(id)));
        }

        /// <summary>
        /// Endpoint to delete Dependent by id.
        /// </summary>
        /// <param name="id">Dependent's id</param>
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
        /// Endpoint to update Dependent by id.
        /// </summary>
        /// <param name="request">Dependent's data</param>
        /// <param name="id">Dependent's id</param>
        /// <returns>TransactionResponse</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<TransactionResponse>> Put(DependentDataRequest request, int id)
        {
            if (id <= 0)
                return BadRequest("Id cannot be 0 or less than.");

            return Ok(new TransactionResponse(new ResultTransaction(await _service.Update(new Dependent(id, request.Name, request.BirthDate,
                (Domain.Enum.Gender)request.Gender, request.EmployeeId), id))));
        }
    }
}
