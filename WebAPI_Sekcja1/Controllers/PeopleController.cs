using Contracts;
using Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Sekcja1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var res = await this.peopleService.GetAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDAsync(int id)
        {
            var res = await this.peopleService.GetByIDAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewPersonDTO newPersonDTO)
        {
            var res = await this.peopleService.PostAsync(newPersonDTO);
            return Ok(res);
        }
    }
}
