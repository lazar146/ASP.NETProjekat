using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Cart;
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
    public class CartController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public CartController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCartQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] CartDTO dto, [FromServices] ICreateCartCommand command)
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
        public IActionResult Put(int id, [FromBody] CartDTO dto, [FromServices] IUpdateCartCommand command)
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
        public IActionResult Delete(int id, [FromServices] IDeleteCartCommand command)
        {
            try
            {
                var dto = new CartDTO();
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
