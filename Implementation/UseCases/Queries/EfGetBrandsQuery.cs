using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation.UseCases.Queries
{
    public class EfGetBrandsQuery : EfUseCase, IGetBrandsQuery
    {
        public EfGetBrandsQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 3;
        public string Name => "Search Brands";

        public string Description => "Search Brands with keyword";

        
        public IEnumerable<BrandsDTO> Execute(BaseSearch request)
        {
            var query = Context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Name.Contains(request.Keyword));
            }

            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x => new BrandsDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

      
    }
}
