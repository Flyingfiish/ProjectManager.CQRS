using MediatR;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Behaviors
{
    public class HashPasswordBehaviour : IPipelineBehavior<CreateCommand<User>, User>
    {
        private readonly IAuthService _authService;
        public HashPasswordBehaviour(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<User> Handle(CreateCommand<User> request, CancellationToken cancellationToken, RequestHandlerDelegate<User> next)
        {
            request.entity.Password = _authService.GetHash(request.entity.Password);
            return await next();
        }
    }
}
