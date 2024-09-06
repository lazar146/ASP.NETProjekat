using Application.UseCases.Commands.Image;
using Application.UseCases.DTO;
using DataAccess;
using System;
using System.IO;
using System.Linq;

namespace Implementation.UseCases.Commands.Image
{
    public class EfDeleteImageCommand : EfUseCase, IDeleteImageCommand
    {
        public EfDeleteImageCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 35;

        public string Name => "Delete Image";

        public string Description => "Delete Image Command";

       
        public void Execute(ImageDTO request)
        {
           
            var image = Context.Images.FirstOrDefault(x => x.Id == request.Id);

            if (image == null)
            {
                throw new ArgumentException("Image not found.");
            }

            
            var filePath = Path.Combine("wwwroot", "images", image.ImageUrl);

            
            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }

           
            Context.Images.Remove(image);
            Context.SaveChanges();
        }
    }
}
