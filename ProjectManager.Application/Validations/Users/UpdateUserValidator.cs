using FluentValidation;
using ProjectManager.Application.Commands.Common;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Validations.Users
{
    public class UpdateUserValidator : AbstractValidator<UpdateCommand<User>>
    {
        public UpdateUserValidator()
        {
        }
    }
}
