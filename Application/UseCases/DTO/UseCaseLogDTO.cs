using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DTO
{
    public class UseCaseLogDTO : BaseDTO
    {
        public string UseCaseName { get; set; }
        public string Username { get; set; }
        public string UseCaseData { get; set; }
        public DateTime ExecutedAt { get; set; }
    }
}
