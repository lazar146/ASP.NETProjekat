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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Implementation.UseCases.Commands.Brand
{
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {

        private BrandCreateValidator _validator;
        public EfCreateBrandCommand(AspProjContext context, BrandCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create Brand";

        public string Description => "Create brand command";

        public void Execute(BrandsDTO request)
        {
            _validator.ValidateAndThrow(request);
            var brand = new Domain.Brand
            {
                Name = request.Name

            };
            Context.Brands.Add(brand);
            Context.SaveChanges();
        }
    }
}
