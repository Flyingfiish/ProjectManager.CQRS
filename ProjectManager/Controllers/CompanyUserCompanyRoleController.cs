using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyUserCompanyRoleController : EntityController<CompanyUserCompanyRole>
    {
        public CompanyUserCompanyRoleController(IMediator mediator) : base(mediator)
        {

        }
    }
}
