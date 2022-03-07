using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Queries.Common
{
    public record GetHashQuery(string value) : IRequest<string>;
}
