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
    public class CreateHandler<T> : IRequestHandler<CreateCommand<T>, T> where T : class, new()
    {
        private readonly IRepository<T> _repository;
        public CreateHandler(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.Create(request.entity);
        }
    }
}
