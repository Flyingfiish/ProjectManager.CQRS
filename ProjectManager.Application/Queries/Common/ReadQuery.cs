using MediatR;
using ProjectManager.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Queries.Common
{
    public record ReadQuery<T>(ISpecification<T> spec) : IRequest<IEnumerable<T>> where T : class, new();
}
