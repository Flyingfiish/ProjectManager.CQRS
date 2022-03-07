using MediatR;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Commands
{
    public record CreateUserCommand(User user) : IRequest<User>;
}
