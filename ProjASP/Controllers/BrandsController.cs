using Application.UseCases.Commands.Brands;
using Application.UseCases.DTO;
using Application.UseCases.Queries;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private UseCaseHandler _useCaseHandler;

        public BrandsController(UseCaseHandler useCaseHandler)
        {
            _useCaseHandler = useCaseHandler;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery]BaseSearch search, [FromServices] IGetBrandsQuery query)
        {
            return Ok(_useCaseHandler.HandleQuery(query,search));
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] BrandsDTO dto, [FromServices] ICreateBrandCommand command)
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
        public IActionResult Put(int id, [FromBody] BrandsDTO dto, [FromServices] IUpdateBrandCommand command)
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
        public IActionResult Delete(int id, [FromServices] IDeleteBrandCommand command)
        {
            try
            {
                var dto = new BrandsDTO();
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
