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
    public class EfGetModelColorQuery : EfUseCase, IGetModelColorQuery
    {
        public EfGetModelColorQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Get Model Color";

        public string Description => "Get Model Color Query";

        public IEnumerable<ModelColorDTO> Execute(BaseSearch request)
        {
            var query = Context.ModelColors.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (int.TryParse(request.Keyword, out int number))
                {

                    query = query.Where(x => x.ModelId == int.Parse(request.Keyword));

                }
                else
                {

                    Console.WriteLine("Keyword must be a number");
                    throw new ArgumentException("Keyword must be a number.");
                }

            }


            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x => new ModelColorDTO
            {
                Id = x.Id,
                ModelId = x.ModelId,
                ColorId = x.ColorId,

            }).ToList();
        }
    }
}
