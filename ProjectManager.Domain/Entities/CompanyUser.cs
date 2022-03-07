using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Entities
{
    public class CompanyUser : Entity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<CompanyRole> CompanyRoles { get; set; }
        
    }
}
