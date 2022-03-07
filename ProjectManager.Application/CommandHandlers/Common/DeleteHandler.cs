using MediatR;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.CommandHandlers.Common
{
    public class DeleteHandler<T> : IRequestHandler<DeleteCommand<T>, Unit> where T : class, new()
    {
        private readonly IRepository<T> _repository;
        public DeleteHandler(IRepository<T> repository)
        {
            _repository = repository;
        }



        async Task<Unit> IRequestHandler<DeleteCommand<T>, Unit>.Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.entity);
            return Unit.Value;
        }
    }
}
