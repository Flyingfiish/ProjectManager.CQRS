using ProjectManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Domain.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? HexColor { get; set; }
        public string? AvatarUri { get; set; }
        public string? Bio { get; set; }
        public DateTime? BirthDate { get; set; }

        public IEnumerable<Company>? Companies { get; set; }
    }
}
