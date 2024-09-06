using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using ProjASP.Application;
using Application.Logging;

namespace ProjASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseLogController : ControllerBase
    {
        private UseCaseHandler _handler;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IApplicationActor _actor;
        private IExeptionLogger _logger;
        public UseCaseLogController(UseCaseHandler handler, IHttpContextAccessor contextAccessor, IApplicationActor actor, IExeptionLogger logger)
        {
            _handler = handler;
            _contextAccessor = contextAccessor;
            _actor = actor;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] UseCaseSearchDTO search, [FromServices] IGetUseCaseLogQuery query)
        {
            try
            {
                var httpMethod = _contextAccessor.HttpContext.Request.Method;
                if (httpMethod != HttpMethods.Get && !_actor.AllowedUseCases.Contains(query.Id))
                {
                    throw new UnauthorizedAccessException();
                }
                var _context = new AspProjContext();

                _context.UseCaseLogs.Add(new Domain.UseCaseLog
                {
                    UseCaseData = "Nes",
                    Username = _actor.Username,
                    UseCaseName = query.Name,
                    ExecutedAt = DateTime.Now,
                });
                _context.SaveChanges();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(search);

                stopwatch.Stop();

                Console.WriteLine(query.Name + ", " + query.Description + ", Duration: " + stopwatch.ElapsedMilliseconds + " ms!");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }
    }
}
