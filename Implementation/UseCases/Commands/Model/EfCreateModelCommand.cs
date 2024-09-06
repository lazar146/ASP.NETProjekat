using Application.UseCases.Commands.Model;
using Application.UseCases.DTO;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validation.Model;
using System;

namespace Implementation.UseCases.Commands.Model
{
    public class EfCreateModelCommand : EfUseCase, ICreateModelCommand
    {
        private ModelCreateValidator _validator;

        public EfCreateModelCommand(AspProjContext context, ModelCreateValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;
        public string Name => "Create Model";
        public string Description => "Create Model command";

        public void Execute(ModelDTO request)
        {
            _validator.ValidateAndThrow(request);
            var model = new Domain.Model
            {
                Name = request.Name,
                Description = request.Description,
                brandId = request.brandId,
                RamMemory = request.RamMemory,
                StorageMemory = request.StorageMemory,
                CameraMegapixels = request.CameraMegapixels
            };

            Context.Models.Add(model);
            Context.SaveChanges();
        }
    }
}
