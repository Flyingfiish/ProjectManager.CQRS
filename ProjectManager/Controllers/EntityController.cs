using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Specifications;
using ProjectManager.Domain.Specifications.Common;
using System.Text.Json;

namespace ProjectManager.Controllers
{
    public class EntityController<T> : ControllerBase where T : Entity, new()
    {
        protected readonly IMediator _mediator;

        public EntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPut]
        [Route("[action]")]
        public virtual async Task<ActionResult> Create([FromBody] T entity)
        {
            var result = await _mediator.Send(new CreateCommand<T>(entity));
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public virtual async Task<ActionResult> Get(Guid id)
        {
            IEnumerable<T> entities = await _mediator.Send(new ReadQuery<T>(new GetByIdSpecification<T>(id)));
            return Ok(entities);
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public virtual async Task<ActionResult> Update([FromBody] T entity)
        {
            var result = await _mediator.Send(new UpdateCommand<T>(entity));
            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]")]
        public virtual async Task<ActionResult> Delete([FromBody] T entity)
        {
            var result = await _mediator.Send(new DeleteCommand<T>(entity));
            return Ok(result);
        }
    }
}
