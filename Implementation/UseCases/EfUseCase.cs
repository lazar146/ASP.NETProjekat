using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly AspProjContext _context;

        protected EfUseCase(AspProjContext context)
        {
            _context = context;
        }

        protected AspProjContext Context => _context;
    }
}
