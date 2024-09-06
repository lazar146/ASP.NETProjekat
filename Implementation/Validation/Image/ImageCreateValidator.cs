using Application.UseCases.DTO;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validation.Image
{
    public class ImageCreateValidator : AbstractValidator<ImageDTO>
    {
        private readonly AspProjContext _context;

        public ImageCreateValidator(AspProjContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ImageName)
                .NotEmpty().WithMessage("ImageName is required.")
                .MinimumLength(2).WithMessage("ImageName must be at least 2 characters long.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                .WithMessage("ImageUrl must be a valid URL.");

            RuleFor(x => x.ModelId)
                .GreaterThan(0).WithMessage("ModelId must be greater than 0.");
        }
    }
}
