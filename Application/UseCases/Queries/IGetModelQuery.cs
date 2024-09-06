using Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public interface IGetModelQuery : IQuery<BaseSearch, IEnumerable<ModelDTO>>
    {
    }
}
