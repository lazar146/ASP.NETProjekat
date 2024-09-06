using Application.UseCases.Commands.Brands;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Brand
{
    public class EfUpdateBrandCommand : EfUseCase, IUpdateBrandCommand
    {

        private BrandCreateValidator _validator;
        public EfUpdateBrandCommand(AspProjContext context, BrandCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Update Brand";

        public string Description => "Update Brand Command";

        public void Execute(BrandsDTO request)
        {
            _validator.ValidateAndThrow(request);

            var brand = Context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();

            Context.Brands.Remove(brand);

            var updated = new Domain.Brand
            {
                Id = request.Id,
                Name = request.Name
            };

            Context.Brands.Add(updated);
            Context.SaveChanges();
        }
    }
}
