using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Application.Services;

namespace ProjectManager.Application.QueryHandlers.Common
{
    internal class GetHashHandler : IRequestHandler<GetHashQuery, string>
    {
        private readonly IAuthService _authService;
        public GetHashHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public Task<string> Handle(GetHashQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_authService.GetHash(request.value));
        }
    }
}
