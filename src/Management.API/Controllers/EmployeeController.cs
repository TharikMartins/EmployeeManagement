using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Domain;
using Management.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;
        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _service.Insert(new Employee(1, "Tharik", DateTime.Now, Domain.Enum.Gender.Male, "01234567890", "02324434443", "Rua dos bobos",
                true, null));

            return Json(new { success = true });
        }
    }
}
