using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Entities
{
    public class CompanyRole : Entity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public bool Hidden { get; set; }

        public IEnumerable<CompanyUser> CompanyUsers { get; set; }
    }
}
