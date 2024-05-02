using MediatR;
namespace Auth.ModelsManipulations.AddUser
{
    public class AddUserCommand : IRequest<bool>
    {
        public string Email;

        public string Password;

        public AddUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}