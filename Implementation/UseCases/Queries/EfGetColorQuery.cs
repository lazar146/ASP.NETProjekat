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
    public class EfGetColorQuery : EfUseCase, IGetColorQuery
    {
        public EfGetColorQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get Color";

        public string Description => "Get Color Query";

        public IEnumerable<ColorDTO> Execute(BaseSearch request)
        {
            var query = Context.Colors.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x => new ColorDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
