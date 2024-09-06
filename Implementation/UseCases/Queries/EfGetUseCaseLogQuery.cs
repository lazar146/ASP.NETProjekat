using Application;
using Application.UseCases.DTO;
using Application.UseCases.Queries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Implementation.UseCases.Queries
{
    public class EfGetUseCaseLogQuery : EfUseCase, IGetUseCaseLogQuery
    {
        public EfGetUseCaseLogQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 34;

        public string Name => "Get UseCase Log";

        public string Description => "Get UseCase Log Query";

        public IEnumerable<UseCaseLogDTO> Execute(UseCaseSearchDTO request)
        {
            var query = Context.UseCaseLogs.AsQueryable();
            if (!string.IsNullOrEmpty(request.Username) || !string.IsNullOrWhiteSpace(request.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(request.Username.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.UseCaseName) || !string.IsNullOrWhiteSpace(request.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(request.UseCaseName.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.DateFrom) || !string.IsNullOrWhiteSpace(request.DateFrom))
            {
                query = query.Where(x => x.ExecutedAt >= DateTime.Parse(request .DateFrom));
            }

            if (!string.IsNullOrEmpty(request.DateTo) || !string.IsNullOrWhiteSpace(request.DateTo))
            {
                query = query.Where(x => x.ExecutedAt <= DateTime.Parse(request.DateTo));
            }
            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
           
            return query.Select(x => new UseCaseLogDTO
            {
                Id = x.Id,
                Username = x.Username,
                UseCaseName = x.UseCaseName,
                UseCaseData = x.UseCaseData,
                ExecutedAt = x.ExecutedAt
            }).ToList();
        }
    }
}
