using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Cart
{
    public class CartCreateValidator : AbstractValidator<CartDTO>
    {
        private AspProjContext _context;
        public CartCreateValidator(AspProjContext context)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}
