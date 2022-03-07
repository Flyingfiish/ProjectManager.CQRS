using MediatR;
using ProjectManager.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Commands.Common
{
    public record DeleteCommand<T>(T entity) : IRequest where T : class, new();
}
