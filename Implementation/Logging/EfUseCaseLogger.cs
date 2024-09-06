using Application;
using DataAccess;
using Implementation.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class EfUseCaseLogger : EfUseCase, IUseCaseLogger
    {
        public EfUseCaseLogger(AspProjContext context) : base(context)
        {
        }

        public void Log(UseCaseLog log)
        {
            var logg = new Domain.UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                Username = log.Username,
                ExecutedAt = DateTime.UtcNow,
                UseCaseData = JsonConvert.SerializeObject(log.UseCaseData)
            };
            Context.UseCaseLogs.Add(logg);

            Context.SaveChanges();

        }
    }
}
