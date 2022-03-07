using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Specifications.Users
{
    public class GetUserByAuthDataSpecification : Specification<User>
    {
        public GetUserByAuthDataSpecification(string login, string password)
        {
            Predicate = user => user.Login == login && user.Password == password;
        }
    }
}
