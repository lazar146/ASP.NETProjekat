using Application.Logging;
using DataAccess;
using Domain;
using ProjASP.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class ConsoleExeptionLogger : IExeptionLogger
    {
       

        public void Log(Exception ex)
        {
            var _context = new AspProjContext();
            _context.ErrorLogs.Add(new ErrorLog
            {
                Message = ex.Message,
                StrackTrace = "**",
                Time = DateTime.UtcNow
            });
            _context.SaveChanges();
            Console.WriteLine("Occured at: " + DateTime.UtcNow);
            Console.WriteLine(ex.Message);
        }
    }
}
