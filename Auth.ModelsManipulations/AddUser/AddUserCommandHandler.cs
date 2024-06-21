using MediatR;
using Auth.ModelsCore;
using Auth.ModelsCore.Exceptions;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

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
            var validator = new AddUserCommandValidator();
            validator.ValidateAndThrow(request);
            if( await CTX.Users.AnyAsync(u => u.Email == request.Email))
            {
                throw new UserAlreadyExistException();
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashOfPassword = BCrypt.Net.BCrypt.HashPassword(request.Password,salt);
            User tempUser = new(request.Email, hashOfPassword,salt);
            CTX.Users.Add(tempUser);
            CTX.SaveChanges();
            return true;
        }


    }
}
