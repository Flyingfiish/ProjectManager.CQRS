using MediatR;
using MediatR.Pipeline;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Common
{
    public class ExceptionHandler<TRequest, TResponse> : RequestExceptionHandler<TRequest, TResponse, Exception>
        where TResponse : Entity, new()
        where TRequest : IRequest<TResponse>
    {
        protected override void Handle(TRequest request, Exception exception, RequestExceptionHandlerState<TResponse> state)
        {
            throw new NotImplementedException();
        }
    }
}
