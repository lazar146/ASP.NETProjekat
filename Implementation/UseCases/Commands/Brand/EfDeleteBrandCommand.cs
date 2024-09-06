using Application.UseCases.Commands.Brands;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Brand
{
    public class EfDeleteBrandCommand : EfUseCase, IDeleteBrandCommand
    {
        public EfDeleteBrandCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Delete Brand";

        public string Description => "Delete Brand Command";

        public void Execute(BrandsDTO request)
        {
            var brand = Context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();

            Context.Brands.Remove(brand);
            Context.SaveChanges();
        }
    }
}
