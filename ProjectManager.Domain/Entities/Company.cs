using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Entities
{
    public class Company : Entity
    {
        public bool Public { get; set; }
        public IEnumerable<CompanyUser> CompanyUsers { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<CompanyRole> CompanyRoles { get; set; }
    }
}
