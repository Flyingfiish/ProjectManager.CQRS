using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyUserController : EntityController<CompanyUser>
    {
        public CompanyUserController(IMediator mediator) : base(mediator)
        {

        }
    }
}
