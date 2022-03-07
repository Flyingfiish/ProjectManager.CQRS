using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Entities
{
    public class CompanyUserCompanyRole : Entity
    {
        public Guid CompanyRoleId { get; set; }
        public CompanyRole CompanyRole { get; set; }
        public Guid CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
    }
}
