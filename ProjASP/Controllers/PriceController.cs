using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Price;
using Application.UseCases.DTO;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public PriceController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<PriceController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetPriceQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<PriceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] PriceDTO dto, [FromServices] ICreatePriceCommand command)
        {
            try
            {
                _useCaseHandler.HandleCommand(command, dto);
                return StatusCode(251);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PriceDTO dto, [FromServices] IUpdatePriceCommand command)
        {
            try
            {
                dto.Id = id;
                _useCaseHandler.HandleCommand(command, dto);
                return StatusCode(251);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePriceCommand command)
        {
            try
            {
                var dto = new PriceDTO();
                dto.Id = id;
                _useCaseHandler.HandleCommand(command, dto);
                return StatusCode(251);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
