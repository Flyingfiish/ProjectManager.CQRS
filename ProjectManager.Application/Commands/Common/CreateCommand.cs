using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Commands.Common
{
    public record CreateCommand<T>(T entity) : IRequest<T> where T : class, new();
}
