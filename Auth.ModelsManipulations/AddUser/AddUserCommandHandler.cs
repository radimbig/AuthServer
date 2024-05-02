using MediatR;
using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;
using Auth.ModelsCore;
using Auth.ModelsCore.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Auth.ModelsManipulations.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, bool>
    {

        AuthDB CTX;
        public AddUserCommandHandler(AuthDB ctx)
        {
            CTX = ctx;
        }
        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if( await CTX.Users.AnyAsync(u => u.Email == request.Email))
            {
                throw new UserAlreadyExistException();
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashOfPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            User tempUser = new(request.Email, request.Password,salt);
            CTX.Users.Add(tempUser);
            CTX.SaveChanges();
            return true;

        }


    }
}
