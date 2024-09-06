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
    public class EfGetImageQuery : EfUseCase, IGetImageQuery
    {
        public EfGetImageQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Get Image";

        public string Description => "Get Image Query";

        public IEnumerable<ImageDTO> Execute(BaseSearch request)
        {
            var query = Context.Images.AsQueryable();

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
            return query.Select(x => new ImageDTO
            {
                Id = x.Id,
                ImageName = x.ImageName,
                ImageUrl = x.ImageUrl,
                ModelId = x.ModelId,

            }).ToList();
        }
    }
}
