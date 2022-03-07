using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Specifications.Common
{
    public class GetByIdSpecification<T> : Specification<T> where T : Entity, new()
    {
        public GetByIdSpecification(Guid id)
        {
            Predicate = entity => entity.Id == id;
        }
    }
}
