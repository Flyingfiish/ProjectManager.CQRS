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
    public class CreateCommandValidator<T> : AbstractValidator<CreateCommand<T>> where T : Entity, new()
    {
        public CreateCommandValidator()
        {
            RuleFor(e => e.entity.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
