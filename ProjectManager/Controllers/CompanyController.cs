using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : EntityController<Company>
    { 
        public CompanyController(IMediator mediator) : base(mediator)
        {

        }
    }
}
