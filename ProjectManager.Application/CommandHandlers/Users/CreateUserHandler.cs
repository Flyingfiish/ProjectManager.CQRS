using MediatR;
using ProjectManager.Application.Commands;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.CommandHandlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
