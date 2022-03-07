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
    public class UpdateCommandValidator<T> : AbstractValidator<UpdateCommand<T>> where T : Entity, new()
    {
        public UpdateCommandValidator()
        {
            RuleFor(e => e.entity.Id)
                .Must(id => id != Guid.Empty);
        }
    }
}
