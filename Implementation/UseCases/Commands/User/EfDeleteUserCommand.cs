using Application.UseCases.Commands.User;
using Application.UseCases.DTO;
using DataAccess;
using System.Linq;

namespace Implementation.UseCases.Commands.User
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(AspProjContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Delete User";

        public string Description => "Delete User Command";

        public void Execute(UserDTO request)
        {
            var user = Context.Users.Where(x => x.Id == request.Id).FirstOrDefault();

            if (user != null)
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
            }
        }
    }
}
