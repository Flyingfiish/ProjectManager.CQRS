using MediatR;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.QueryHandlers.Common
{
    public class GetTokenHandler : IRequestHandler<GetTokenQuery, string>
    {
        private readonly IAuthService _authService;
        public GetTokenHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<string> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            return await _authService.CreateToken(request.login, request.password);
        }
    }
}
