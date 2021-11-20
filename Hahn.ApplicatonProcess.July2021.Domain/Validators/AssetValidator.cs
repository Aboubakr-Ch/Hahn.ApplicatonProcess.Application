using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<Asset>
    {
        public AssetValidator()
        {
            RuleFor(model => model.Id).NotEmpty();
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Symbol).NotEmpty();
        }
    }
}
