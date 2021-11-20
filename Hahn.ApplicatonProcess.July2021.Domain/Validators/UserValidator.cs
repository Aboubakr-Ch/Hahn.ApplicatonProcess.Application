using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(model => model.Age).GreaterThanOrEqualTo(18);
            RuleFor(model => model.FirstName).MinimumLength(3);
            RuleFor(model => model.LastName).MinimumLength(3);
            RuleFor(model => model.Address).NotEmpty();
            RuleFor(model => model.Email).EmailAddress();
        }
    }
}
