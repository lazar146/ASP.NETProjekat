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
    public class EfGetCartQuery : EfUseCase, IGetCartQuery
    {
        public EfGetCartQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Get Cart";

        public string Description => "Get Cart Query";

        public IEnumerable<CartDTO> Execute(BaseSearch request)
        {
            var query = Context.Carts.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (int.TryParse(request.Keyword, out int number))
                {
                    
                    query = query.Where(x => x.UserId == int.Parse(request.Keyword));
                    
                }
                else
                {
                    
                    Console.WriteLine("Keyword must be a number");
                    throw new ArgumentException("Keyword must be a number.");
                }
                
            }
            
            
            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x=> new CartDTO
            {
                Id = x.Id,
                UserId = x.UserId,

            }).ToList();
        }
    }
}
