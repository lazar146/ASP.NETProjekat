using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.ProductCart
{
    public class ProductCartCreateValidator : AbstractValidator<ProductCartDTO>
    {
        private AspProjContext _context;

        public ProductCartCreateValidator(AspProjContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.ModelColorId)
                .GreaterThan(0).WithMessage("ModelColorId must be greater than 0.");

            RuleFor(x => x.CartId)
                .GreaterThan(0).WithMessage("CartId must be greater than 0.");
        }
    }
}
