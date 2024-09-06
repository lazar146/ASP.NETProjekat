﻿using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries
{
    public class EfGetPriceQuery : EfUseCase, IGetPriceQuery
    {
        public EfGetPriceQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Get Price";

        public string Description => "Get Price Query";

        public IEnumerable<PriceDTO> Execute(BaseSearch request)
        {
            var query = Context.Prices.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (int.TryParse(request.Keyword, out int number))
                {

                    query = query.Where(x => x.ModelColorId == int.Parse(request.Keyword));

                }
                else
                {

                    Console.WriteLine("Keyword must be a number");
                    throw new ArgumentException("Keyword must be a number.");
                }

            }


            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x => new PriceDTO
            {
                Id = x.Id,
                ModelColorId = x.ModelColorId,
                PriceValue = x.PriceValue,

            }).ToList();
        }
    }
}
