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
    public class EfGetUserQuery : EfUseCase, IGetUserQuery
    {
        public EfGetUserQuery(AspProjContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Get User";

        public string Description => "Get User Query";

        public IEnumerable<UserDTO> Execute(BaseSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Username.Contains(request.Keyword));
            }

            var skipCount = (request.Page.GetValueOrDefault(1) - 1) * request.ItemsPerPage.GetValueOrDefault(1);
            query = query.Skip(skipCount).Take(request.ItemsPerPage.GetValueOrDefault(1));
            return query.Select(x => new UserDTO
            {
                Id = x.Id,
                UserName = x.Username,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Password = "**",
                Email = x.Email,
                BirthDate = x.BirthDate,
            }).ToList();
        }
    }
}
