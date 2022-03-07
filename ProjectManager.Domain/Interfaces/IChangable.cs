using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Interfaces
{
    public interface IChangable
    {
        public DateTime CreatedOn { get; set; }
        public Guid? CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedById { get; set; }
        public User? ModifiedBy { get; set; }
    }
}
