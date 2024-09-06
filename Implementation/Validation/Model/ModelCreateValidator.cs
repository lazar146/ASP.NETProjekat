using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Model
{
    public class ModelCreateValidator : AbstractValidator<ModelDTO>
    {
        private readonly AspProjContext _context;

        public ModelCreateValidator(AspProjContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MinimumLength(10).WithMessage("Description must be at least 10 characters long.");

            RuleFor(x => x.brandId)
                .GreaterThan(0).WithMessage("BrandId must be greater than 0.");

            RuleFor(x => x.RamMemory)
                .GreaterThan(0).WithMessage("RamMemory must be greater than 0.");

            RuleFor(x => x.StorageMemory)
                .GreaterThan(0).WithMessage("StorageMemory must be greater than 0.");

            RuleFor(x => x.CameraMegapixels)
                .GreaterThan(0).WithMessage("CameraMegapixels must be greater than 0.");
        }
    }
}
