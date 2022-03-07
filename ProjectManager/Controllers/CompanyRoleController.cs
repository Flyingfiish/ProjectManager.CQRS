using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyRoleController : EntityController<CompanyRole>
    {
        public CompanyRoleController(IMediator mediator) : base(mediator)
        {

        }
    }
}
