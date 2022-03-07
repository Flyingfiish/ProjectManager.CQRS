using MediatR;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.QueryHandlers.Common
{
    public class ReadHandler<T> : IRequestHandler<ReadQuery<T>, IEnumerable<T>> where T : class, new()
    {
        private readonly IRepository<T> _repository;
        public ReadHandler(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> Handle(ReadQuery<T> request, CancellationToken cancellationToken)
        {
            IEnumerable<T> result = await _repository.ReadMany(request.spec);
            if(result.Count() == 0)
            {
                throw new ArgumentException("Not found");
            }
            return result;
        }
    }
}
