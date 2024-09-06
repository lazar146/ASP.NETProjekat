using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries
{
    public class EfGetModelQuery : EfUseCase, IGetModelQuery
    {
        public EfGetModelQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Get Model";

        public string Description => "Get Model Query";

        public IEnumerable<ModelDTO> Execute(BaseSearch request)
        {
            var query = Context.Models.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x => new ModelDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                brandId = x.brandId,
                RamMemory = x.RamMemory,
                CameraMegapixels = x.CameraMegapixels,
                StorageMemory = x.StorageMemory,
            }).ToList();
        }
    }
}
