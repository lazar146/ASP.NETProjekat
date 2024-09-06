using Application;
using Application.Logging;
using Application.UseCases;
using DataAccess;
using Domain;
using Implementation.UseCases;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Security;
using ProjASP.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Implementation
{
    public class UseCaseHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IApplicationActor _actor;
        private IExeptionLogger _logger;
        public UseCaseHandler(IExeptionLogger logger, IApplicationActor actor, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _actor = actor;
            _contextAccessor = contextAccessor;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command,TRequest data)
        {
            
            try
			{

                if(command.Id != 17)
                {
                    if (!_actor.AllowedUseCases.Contains(command.Id))
                    {
                        throw new UnauthorizedAccessException();
                    }
                }
               
                var _context = new AspProjContext();

                _context.UseCaseLogs.Add(new Domain.UseCaseLog
                {
                    UseCaseData = "Nes",
                    Username = _actor.Username,
                    UseCaseName = command.Name,
                    ExecutedAt = DateTime.Now,
                });
                _context.SaveChanges();
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + ", Duration: " + stopwatch.ElapsedMilliseconds + " ms!");
               
            }
			catch (Exception ex)
			{
                _logger.Log(ex);
				throw;
			}
        }
        
        public TResult HandleQuery<TRequest, TResult>(IQuery<TRequest,TResult> query,TRequest data)
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

               var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name +", "+ query.Description + ", Duration: " + stopwatch.ElapsedMilliseconds + " ms!");

                return response;
            }
			catch (Exception ex)
			{
                _logger.Log(ex);
				throw;
			}
        }
    }
}
