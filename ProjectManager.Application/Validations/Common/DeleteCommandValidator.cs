using FluentValidation;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Validations.Common
{
    public class DeleteCommandValidator<T> : AbstractValidator<DeleteCommand<T>> where T : Entity, new()
    {
        public DeleteCommandValidator()
        {
            RuleFor(e => e.entity.Id)
                .Must(id => id != Guid.Empty);
        }
    }
}
