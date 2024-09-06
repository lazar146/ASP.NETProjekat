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
    public class ProductCartController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public ProductCartController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }

        // GET: api/<ProductCartController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetProductCartQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query, search));
        }

        // GET api/<ProductCartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ProductCartDTO dto, [FromServices] ICreateProductCartCommand command)
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
        public IActionResult Put(int id, [FromBody] ProductCartDTO dto, [FromServices] IUpdateProductCartCommand command)
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
        public IActionResult Delete(int id, [FromServices] IDeleteProductCartCommand command)
        {
            try
            {
                var dto = new ProductCartDTO();
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
